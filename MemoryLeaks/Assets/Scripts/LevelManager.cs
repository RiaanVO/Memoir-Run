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

		Debug.Log ("CurrentLevel:   " + PlayerPrefs.GetString("CurrentLevel"));
		Debug.Log ("LevelsUnlocked:   " + PlayerPrefs.GetInt("LevelsUnlocked"));

		Debug.Log ("CanDoubleJump:   " + PlayerPrefs.GetInt("CanDoubleJump"));
		Debug.Log ("CanPunch:   " + PlayerPrefs.GetInt("CanPunch"));
		Debug.Log ("CanShoot:   " + PlayerPrefs.GetInt("CanShoot"));
		Debug.Log ("");

		//PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		//PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		//PlayerPrefs.SetString ("CurrentLevel", startingLevel);
		//PlayerPrefs.SetInt ("LevelsUnlocked", levelsUnlocked);

		//PlayerPrefs.SetInt ("CanDoubleJump", canDoubleJump);
		//PlayerPrefs.SetInt ("CanPunch", canPunch);
		//PlayerPrefs.SetInt ("CanShoot", canShoot);
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
		gravityStore = player.GetComponent<Rigidbody2D> ().gravityScale;
		player.GetComponent<Rigidbody2D> ().gravityScale = 0;
		player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);

		cameraController.isFollowing = false;

		yield return new WaitForSeconds (respawnDelay);

		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);

		player.transform.position = currentCheckpoint.transform.position;

		cameraController.isFollowing = true;
		player.enabled = true;
		player.GetComponent<SpriteRenderer> ().enabled = true;
		player.GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
		player.respawnPlayer ();
	}
}
