using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private PlayerController player;
	public GameObject currentCheckpoint;

	private CameraController cameraController;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;

	private float gravityStore;

	public string currentLevel;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		//healthManager = FindObjectOfType<HealthManager> ();
		cameraController = FindObjectOfType<CameraController> ();

		PlayerPrefs.SetString ("CurrentLevel", currentLevel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);

		player.enabled = false;
		player.GetComponent<SpriteRenderer> ().enabled = false;
		//ScoreManager.AddPoints (-pointPenaltyOnDeath);
		cameraController.isFollowing = false;
		player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);

		yield return new WaitForSeconds (respawnDelay);

		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);

		player.transform.position = currentCheckpoint.transform.position;

		cameraController.isFollowing = true;
		player.enabled = true;
		player.GetComponent<SpriteRenderer> ().enabled = true;
		player.respawnPlayer ();
	}
}
