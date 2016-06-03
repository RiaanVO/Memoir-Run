using UnityEngine;
using System.Collections;

public class MemoryBlastController : MonoBehaviour {

	public int damageToGive;
	public float moveSpeed;
	public float lifeTime;
	private Rigidbody2D rb2d;
	private Animator anim;

	private PlayerController player;
	private bool exploded = false;

	private bool removeGameObject = false;

	public AudioSource explodeSource;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		player = FindObjectOfType<PlayerController> ();
		moveSpeed = Mathf.Sign(player.transform.localScale.x) * moveSpeed;
		transform.localScale = new Vector3 (player.transform.localScale.x, 1, 1);
	}

	// Update is called once per frame
	void Update () {
		if (removeGameObject && !explodeSource.isPlaying) {
			Destroy (gameObject);
		}

		if (exploded)
			return;
		if (lifeTime < 0) {
			exploded = true;
			rb2d.velocity = new Vector3(0,0,0);
			anim.SetTrigger ("Explode");
			return;
		}
		lifeTime -= Time.deltaTime;
		rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);

	}

	void OnTriggerEnter2D (Collider2D other){
		rb2d.velocity = new Vector3(0,0,0);
		anim.SetTrigger ("Explode");

		if (other.tag == "Enemy" && !exploded) {
			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
			//Destroy (other.gameObject);
		}
		exploded = true;
	}

	public void playExplosionSound(){
		explodeSource.Play ();
	}

	public void removeBlast(){
		removeGameObject = true;
		//Destroy (gameObject);
	}
}
