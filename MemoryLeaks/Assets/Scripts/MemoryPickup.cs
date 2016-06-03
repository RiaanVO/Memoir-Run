using UnityEngine;
using System.Collections;

public class MemoryPickup : MonoBehaviour {

	public int memoriesToAdd;

	public int xRandomRange;
	public int yRandomRange;
	public float spreadForce;
	public bool startRandom = true;


	private bool onGround;
	public LayerMask whatIsGround;
	public float groundCheckRadius;

	private Animator anim;
	private Rigidbody2D rb2d;


	private bool removeGameObject = false;
	//public AudioClip memoryCollectSound;
	public AudioSource memoryCollectSource;
	public CircleCollider2D collisionCollider;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		if (startRandom) {
			rb2d.AddForce (new Vector2 (Random.Range (-xRandomRange, xRandomRange) * spreadForce, Random.Range (yRandomRange, yRandomRange * 2) * spreadForce));
		}
	}

	// Update is called once per frame
	void Update () {
		onGround = Physics2D.OverlapCircle (transform.position, groundCheckRadius);
		anim.SetBool ("onGround", onGround);

		if (removeGameObject && !memoryCollectSource.isPlaying) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player" && !removeGameObject) {
			memoryCollectSource.Play();
			GetComponent<SpriteRenderer> ().enabled = false;
			collisionCollider.enabled = false;

			other.GetComponent<HealthManager>().HealPlayer(memoriesToAdd);
			removeGameObject = true;
		}

		if (other.tag == "Hazzard")
			Destroy (gameObject);
	}

	void OnBecameInvisable(){
		Destroy (gameObject);
	}
}
