using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelSelect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewGame(){
		SceneManager.LoadScene (startLevel);
	}

	public void LevelSelect(){
		SceneManager.LoadScene (levelSelect);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
