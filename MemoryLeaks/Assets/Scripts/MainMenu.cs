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

		} else if (Input.GetKeyDown (KeyCode.P)) {
			Debug.Log ("Thank you for not cheating");
			playerHealth = playerHealthStore;
			playerLives = playerLivesStore;
			levelsUnlocked = levelsUnlockedStore;
			canDoubleJump = canDoubleJumpStore;
			canPunch = canPunchStore;
			canShoot = canShootStore;
			PlayerPrefs.SetString ("CurrentLevel", "");
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
	}

	public void ContinueGame(){
		AudioSource.PlayClipAtPoint (selectSound, transform.position);

		SceneManager.LoadScene (PlayerPrefs.GetString("CurrentLevel"));
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
