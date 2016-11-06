using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public static GameManager gm;

	[Tooltip("If not set, the player will default to the gameObject tagged as Player.")]
	public GameObject player;

	public enum gameStates {Playing, Death, GameOver, BeatLevel};
	public gameStates gameState = gameStates.Playing;

	public int score=0;
	public int totalScore=0;
	public bool canBeatLevel = false;
	public int beatLevelScore=0;

	public GameObject mainCanvas;
	public Text mainScoreDisplay;
	public Text totalScoreDisplay;
	public GameObject gameOverCanvas;
	public Text gameOverScoreDisplay;

	public GameObject beatLevelCanvas;

	public AudioSource backgroundMusic;
	public AudioClip gameOverSFX;

	public AudioClip beatLevelSFX;

	private Health playerHealth;

	void Start () {
		if (gm == null) 
			gm = gameObject.GetComponent<GameManager>();

		if (player == null) {
			player = GameObject.FindWithTag("Player");
		}

		playerHealth = player.GetComponent<Health>();

		// setup score display
		Collect (0);

		// make other UI inactive
		gameOverCanvas.SetActive (false);
		if (canBeatLevel)
			beatLevelCanvas.SetActive (false);
	}

	void Update () {
		switch (gameState)
		{
			case gameStates.Playing:
				if (playerHealth.isAlive == false)
				{
					// update gameState
					gameState = gameStates.Death;

					// set the end game score
					gameOverScoreDisplay.text = mainScoreDisplay.text;

					// switch which GUI is showing		
					mainCanvas.SetActive (false);
					gameOverCanvas.SetActive (true);
				} else if (canBeatLevel && score>=beatLevelScore) {
				
					//
				//Debug.Log ("FF");
					// 
					//
				if (beatLevelScore == 6) {
					GameObject wall2 = GameObject.FindWithTag ("wall1");
					Destroy (wall2, 0.0f);
					beatLevelScore = 4;
					score = 0;
					Collect (0);
					}
				else
				{		// update gameState
					UnityStandardAssets.Vehicles.Ball.Ball.m_JumpPower=0.3f;
					gameState = gameStates.BeatLevel;
					//hide the player so game doesn't continue playing
					player.SetActive(false);
					// switch which GUI is showing	
					mainCanvas.SetActive (false);
					beatLevelCanvas.SetActive (true);
				}
				}
				break;
			case gameStates.Death:
				backgroundMusic.volume -= 0.01f;
			UnityStandardAssets.Vehicles.Ball.Ball.m_JumpPower=0.3f;
				if (backgroundMusic.volume<=0.0f) {
					AudioSource.PlayClipAtPoint (gameOverSFX,gameObject.transform.position);

					gameState = gameStates.GameOver;
				}
				break;
			case gameStates.BeatLevel:
				backgroundMusic.volume -= 0.01f;
			UnityStandardAssets.Vehicles.Ball.Ball.m_JumpPower=0.3f;
				if (backgroundMusic.volume<=0.0f) {
					AudioSource.PlayClipAtPoint (beatLevelSFX,gameObject.transform.position);
			
					gameState = gameStates.GameOver;
				}
				break;
		case gameStates.GameOver:
				UnityStandardAssets.Vehicles.Ball.Ball.m_JumpPower = 0.3f;
				break;
		}

	}


	public void Collect(int amount) {
		score += amount;
		totalScore += amount;
		if (canBeatLevel) {
			mainScoreDisplay.text = score.ToString () + " of "+beatLevelScore.ToString ();
			totalScoreDisplay.text = totalScore.ToString () + "/20";
		} else {
			mainScoreDisplay.text = score.ToString ();
		}

	}
}
