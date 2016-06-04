using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public string levelSelect;
	public Button continueButton;

	public int playerHealth;
	public int playerMaxHealth;
	public int playerLives;
	public int playerMaxLives;
	public string startingLevel;
	public int levelsUnlocked;

	//If they are 0 means you can't else you can
	public int canDoubleJump;
	public int canPunch;
	public int canShoot;

	//Cheat codes ========================================================
	private int playerHealthStore;
	private int playerLivesStore;
	private string startingLevelStore;
	private int levelsUnlockedStore;

	//If they are 0 means you can't else you can
	private int canDoubleJumpStore;
	private int canPunchStore;
	private int canShootStore;
	//===================================================================

	private bool cheatingEnabled = false;

	public AudioClip selectSound;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("PlayerMaxHealth", playerMaxHealth);
		PlayerPrefs.SetInt ("PlayerMaxLives", playerMaxLives);

		playerHealthStore = playerHealth;
		playerLivesStore = playerLives;
		levelsUnlockedStore = levelsUnlocked;
		canDoubleJumpStore = canDoubleJump;
		canPunchStore = canPunch;
		canShootStore = canShoot;

		//displayPlayerPrefs ();
	}

	private void displayPlayerPrefs(){
		Debug.Log ("CurrentLevel:   " + PlayerPrefs.GetString("CurrentLevel"));
		Debug.Log ("LevelsUnlocked:   " + PlayerPrefs.GetInt("LevelsUnlocked"));

		Debug.Log ("CanDoubleJump:   " + PlayerPrefs.GetInt("CanDoubleJump"));
		Debug.Log ("CanPunch:   " + PlayerPrefs.GetInt("CanPunch"));
		Debug.Log ("CanShoot:   " + PlayerPrefs.GetInt("CanShoot"));
		Debug.Log ("");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.O)) {
			Debug.Log ("You Cheater");
			playerHealth = playerMaxHealth;
			playerLives = playerMaxLives;
			levelsUnlocked = 5;
			canDoubleJump = 1;
			canPunch = 1;
			canShoot = 1;
			PlayerPrefs.SetString ("CurrentLevel", "Level_1");
			//displayPlayerPrefs ();
			cheatingEnabled = true;


		} else if (Input.GetKeyDown (KeyCode.P)) {
			Debug.Log ("Thank you for not cheating");
			playerHealth = playerHealthStore;
			playerLives = playerLivesStore;
			levelsUnlocked = levelsUnlockedStore;
			canDoubleJump = canDoubleJumpStore;
			canPunch = canPunchStore;
			canShoot = canShootStore;
			PlayerPrefs.SetString ("CurrentLevel", "");
			//displayPlayerPrefs ();
			cheatingEnabled = false;


		}

		if (cheatingEnabled) {
			if (Input.GetKeyDown (KeyCode.F1)) {
				Debug.Log ("F1 Pressed");
				PlayerPrefs.SetInt ("CanDoubleJump", 0);
				PlayerPrefs.SetInt ("CanPunch", 0);
				PlayerPrefs.SetInt ("CanShoot", 0);
				PlayerPrefs.SetString ("CurrentLevel", "Level_1");
			}

			if (Input.GetKeyDown (KeyCode.F2)) {
				Debug.Log ("F2 Pressed");
				PlayerPrefs.SetInt ("CanDoubleJump", 1);
				PlayerPrefs.SetInt ("CanPunch", 1);
				PlayerPrefs.SetInt ("CanShoot", 0);
				PlayerPrefs.SetString ("CurrentLevel", "Level_2");
			}

			if (Input.GetKeyDown (KeyCode.F3)) {
				Debug.Log ("F3 Pressed");
				PlayerPrefs.SetInt ("CanDoubleJump", 1);
				PlayerPrefs.SetInt ("CanPunch", 1);
				PlayerPrefs.SetInt ("CanShoot", 0);
				PlayerPrefs.SetString ("CurrentLevel", "Level_3");
			}

			if (Input.GetKeyDown (KeyCode.F4)) {
				Debug.Log ("F4 Pressed");
				PlayerPrefs.SetInt ("CanDoubleJump", 1);
				PlayerPrefs.SetInt ("CanPunch", 1);
				PlayerPrefs.SetInt ("CanShoot", 1);
				PlayerPrefs.SetString ("CurrentLevel", "Level_4");
			}

			if (Input.GetKeyDown (KeyCode.F5)) {
				Debug.Log ("F5 Pressed");
				PlayerPrefs.SetInt ("CanDoubleJump", 1);
				PlayerPrefs.SetInt ("CanPunch", 1);
				PlayerPrefs.SetInt ("CanShoot", 1);
				PlayerPrefs.SetString ("CurrentLevel", "Level_5");
			}
		
		}

		if (PlayerPrefs.GetString ("CurrentLevel") == "") {
			continueButton.interactable = false;
		} else {
			continueButton.interactable = true;
		}
	}

	public void NewGame(){
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		PlayerPrefs.SetString ("CurrentLevel", startingLevel);
		PlayerPrefs.SetInt ("LevelsUnlocked", levelsUnlocked);

		PlayerPrefs.SetInt ("CanDoubleJump", canDoubleJump);
		PlayerPrefs.SetInt ("CanPunch", canPunch);
		PlayerPrefs.SetInt ("CanShoot", canShoot);

		AudioSource.PlayClipAtPoint (selectSound, transform.position);
		SceneManager.LoadScene (PlayerPrefs.GetString("CurrentLevel"));

		//displayPlayerPrefs ();

	}

	public void ContinueGame(){
		AudioSource.PlayClipAtPoint (selectSound, transform.position);

		//Debug.Log (PlayerPrefs.GetString ("CurrentLevel"));
		SceneManager.LoadScene (PlayerPrefs.GetString("CurrentLevel"));

		//displayPlayerPrefs ();

	}

	public void LevelSelect(){
		AudioSource.PlayClipAtPoint (selectSound, transform.position);

		SceneManager.LoadScene (levelSelect);
	}

	public void QuitGame(){
		AudioSource.PlayClipAtPoint (selectSound, transform.position);

		Application.Quit ();
	}
		
}
