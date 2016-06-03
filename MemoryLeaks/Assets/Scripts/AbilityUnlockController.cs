using UnityEngine;
using System.Collections;

public class AbilityUnlockController : MonoBehaviour {

	public string abilityName;
	public string prefType;
	public string stringValue;
	public int intValue;
	public float floatValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			switch (prefType) {
			case "string":
				if (stringValue == null) {
					return;
				}
				PlayerPrefs.SetString (abilityName, stringValue);
				break;

			case "int":
				PlayerPrefs.SetInt (abilityName, intValue);
				break;

			case "float":
				PlayerPrefs.SetFloat (abilityName, floatValue);
				break;

			}
		}
	}
}
