using UnityEngine;
using System.Collections;

public class ButtonAudioController : MonoBehaviour {

	public AudioClip mouseOver;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		Debug.Log ("MouseOver");
		AudioSource.PlayClipAtPoint (mouseOver, transform.position);
	}
}
