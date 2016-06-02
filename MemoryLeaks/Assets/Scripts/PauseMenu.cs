using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;

	public bool isPaused;
	public GameObject pauseMenuCanvas;
	private PlayerController player;

	void Start(){
		player = FindObjectOfType<PlayerController> ();
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
	}

	public void Resume(){
		isPaused = false;
	}

	public void LevelSelect(){
		Time.timeScale = 1;
		isPaused = false;
		SceneManager.LoadScene (levelSelect);
	}

	public void MainMenu(){
		Time.timeScale = 1;
		isPaused = false;
		SceneManager.LoadScene (mainMenu);
	}
}
