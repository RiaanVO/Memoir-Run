using UnityEngine;
using System.Collections;

public class DialogZoneController : MonoBehaviour {

	private bool hasBeenShown = false;
	private bool playerInZone = false;

	public int startLine;
	public int endLine;
	public bool timeScaled = false;

	private TextBoxManager tbManager;

	// Use this for initialization
	void Start () {
		tbManager = FindObjectOfType<TextBoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tbManager.isActive)
			return;
		
		if (playerInZone && Input.GetAxisRaw("Vertical") == -1){
			//Debug.Log ("Redisplaying text");
			tbManager.displayText (startLine, endLine, false);
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			playerInZone = true;
			if (!hasBeenShown) {
				tbManager.displayText (startLine, endLine, timeScaled);
				hasBeenShown = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.name == "Player") {
			playerInZone = false;
		}
	}
}
