using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;

	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endLine;

	public bool isActive;

	private PlayerController player;

	// Use this for initialization
	void Start () {

		if (textFile != null) {
		
			textLines = textFile.text.Split ('\n');
		}

		textBox.SetActive (isActive);

		player = FindObjectOfType<PlayerController> ();

		if (endLine == 0)
			endLine = textLines.Length-1;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isActive)
			return;
		player.enabled = false;
		theText.text = textLines [currentLine];
	
		if (Input.GetButtonDown ("Jump")) {
			currentLine++;
		}
	
		if (currentLine > endLine) {
			isActive = false;
			textBox.SetActive (false);
			player.enabled = true;
			if (Time.timeScale == 0)
				Time.timeScale = 1;
		}
	}

	public void displayText(int startLine, int newEndLine, bool timeScaled){
		currentLine = startLine - 1;
		endLine = newEndLine - 1;
		isActive = true;
		if (timeScaled) {
			Time.timeScale = 0;
		} else {
			player.stopMoving ();
		}
		player.enabled = false;
		textBox.SetActive (true);
	}
}
