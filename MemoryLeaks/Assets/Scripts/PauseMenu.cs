using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;

	public bool isPaused;
	public GameObject pauseMenuCanvas;
	private PlayerController player;

	public AudioSource menuSelectAudioSource;


	private bool changeScene = false;
	private string nextScene = "";
	void Start(){
		player = FindObjectOfType<PlayerController> ();
		changeScene = false;
		isPaused = false;
	}

	// Update is called once per frame
	void Update () {
		player.enabled = !isPaused;
		if (isPaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
		pauseMenuCanvas.SetActive (isPaused);

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
		}

		if (changeScene && !menuSelectAudioSource.isPlaying) {
			Time.timeScale = 1;
			isPaused = false;
			SceneManager.LoadScene (nextScene);
		}
	}

	public void Resume(){
		isPaused = false;
		menuSelectAudioSource.Play ();
	}

	public void LevelSelect(){
		menuSelectAudioSource.Play ();
		nextScene = levelSelect;
		changeScene = true;
		//SceneManager.LoadScene (levelSelect);
	}

	public void MainMenu(){
		menuSelectAudioSource.Play ();
		nextScene = mainMenu;
		changeScene = true;
		//SceneManager.LoadScene (mainMenu);
	}
}
