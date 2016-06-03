using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	private LevelManager levelManager;
	public AudioSource CheckpointActivateAudioSource;
	private SpriteRenderer spriteRenderer;
	public Sprite offCheckpoint;
	public Sprite onCheckpoint;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (levelManager.currentCheckpoint != gameObject) {
			spriteRenderer.sprite = offCheckpoint;
		} else {
			spriteRenderer.sprite = onCheckpoint;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			if (levelManager.currentCheckpoint != gameObject) {
				levelManager.currentCheckpoint = gameObject;
				CheckpointActivateAudioSource.Play ();
			}
		}
	}
}
