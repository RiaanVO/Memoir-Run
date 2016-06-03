using UnityEngine;
using System.Collections;

public class BoxManager : MonoBehaviour {

	public AudioSource boxBreak;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void boxBreakSound(){
		boxBreak.Play ();
	}
}
