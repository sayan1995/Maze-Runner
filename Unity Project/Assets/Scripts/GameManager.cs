using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System; 


public class GameManager : MonoBehaviour {

	public static GameManager gm;

	[Tooltip("If not set, the player will default to the gameObject tagged as Player.")]
	public GameObject player;

	public enum gameStates {Playing, Death, GameOver, BeatLevel};
	public gameStates gameState = gameStates.Playing;

	public int score=0;
	public float totalScore;
	public bool canBeatLevel = false;
	public int beatLevelScore=0;

	public GameObject mainCanvas;
	public Text mainScoreDisplay;
	public Text totalScoreDisplay;
	public GameObject gameOverCanvas;
	public Text gameOverScoreDisplay;
	public bool death;
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
		totalScore = 0;
		// setup score display
		Collect (0);

		// make other UI inactive
		gameOverCanvas.SetActive (false);
		if (canBeatLevel)
			beatLevelCanvas.SetActive (false);
		death = false;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("1");
		}
		if (Application.loadedLevelName == "scene4") {
			if (Input.GetKeyDown(KeyCode.Tab)) {
				Application.LoadLevel("scene5");
			}
		}
		if (death == false && Application.loadedLevelName == "scene4") {
			totalScore += Time.deltaTime;
			string p = totalScore.ToString ();
			string k = p.Substring (0, 4);
			totalScoreDisplay.text = k + "/40";
			int score1 = (int)Math.Ceiling (totalScore);
			//Debug.Log (score1);
			if (score1 >= 40) {
				playerHealth.isAlive = false;
				death = true;
			}
		}
		if (death == false && Application.loadedLevelName == "scene5") {
			totalScore += Time.deltaTime;
			string p = totalScore.ToString ();
			string k = p.Substring (0, 4);
			totalScoreDisplay.text = k + "/80";
			int score1 = (int)Math.Ceiling (totalScore);
			Debug.Log (score1);
			if (score1 >= 80) {
				playerHealth.isAlive = false;
				death = true;
			}
		}
			
		switch (gameState) {
		case gameStates.Playing:
			if (playerHealth.isAlive == false) {
				if(Application.loadedLevelName == "scene5"||Application.loadedLevelName == "scene4")
				death = true;
				// update gameState
				gameState = gameStates.Death;

				// set the end game score
				gameOverScoreDisplay.text = mainScoreDisplay.text;

				// switch which GUI is showing		
				mainCanvas.SetActive (false);

				//totalScore = totalScore - Time.time;
			
				Debug.Log (totalScore);
				Debug.Log (Time.time);


				gameOverCanvas.SetActive (true);
			} else if (canBeatLevel && score >= beatLevelScore) {
				
				//
				//Debug.Log ("FF");
				// 
				//
				if (Application.loadedLevelName == "scene3") {
					Debug.Log ("FF1");
					if (beatLevelScore == 6) {
						GameObject wall2 = GameObject.FindWithTag ("wall1");
						Destroy (wall2, 0.0f);

						score = 0;
						Debug.Log ("FF");
						Collect (0);
						beatLevelScore = 4;
						Debug.Log ("F23232F");

					} else {
						Debug.Log ("F23232F");
						// update gameState
						UnityStandardAssets.Vehicles.Ball.Ball.m_JumpPower = 0.3f;
						gameState = gameStates.BeatLevel;
						//hide the player so game doesn't continue playing
						player.SetActive (false);
						// switch which GUI is showing	
						mainCanvas.SetActive (false);
						beatLevelCanvas.SetActive (true);
					}
				} 
				if (Application.loadedLevelName == "scene4") {
					if (beatLevelScore == 6) {
						GameObject wall2 = GameObject.FindWithTag ("wall1");
						Destroy (wall2, 0.0f);
						beatLevelScore = 12;
						score = 0;
						Collect (0);
					} else {		// update gameState
						UnityStandardAssets.Vehicles.Ball.Ball.m_JumpPower = 0.3f;
						gameState = gameStates.BeatLevel;
						//hide the player so game doesn't continue playing
						player.SetActive (false);
						// switch which GUI is showing	
						mainCanvas.SetActive (false);
						beatLevelCanvas.SetActive (true);
					}
				}

				/*if (Application.loadedLevelName == "scene5"){
					if (beatLevelScore == 10) {
						GameObject wall2 = GameObject.FindWithTag ("wall1");
						Destroy (wall2, 0.0f);
						beatLevelScore = 12;
						score = 0;
						Collect (0);
					}
			}*/
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

		if (canBeatLevel) {
			mainScoreDisplay.text = score.ToString () + " of "+beatLevelScore.ToString ();

		} else {
			mainScoreDisplay.text = score.ToString ();
		}

	}
}
