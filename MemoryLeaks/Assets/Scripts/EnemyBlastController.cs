using UnityEngine;
using System.Collections;

public class EnemyBlastController : MonoBehaviour {

	public int damageToGive;
	public float moveSpeed;
	public float lifeTime;
	public float scale;

	private Rigidbody2D rb2d;
	private Animator anim;
	private PlayerController player;
	private bool exploded = false;

	private Vector2 targetDirection;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		player = FindObjectOfType<PlayerController> ();

		targetDirection = player.transform.position - transform.position;
		targetDirection.Normalize ();

		transform.localScale = new Vector3 (Mathf.Sign(targetDirection.x) * scale, 1 * scale, 1);
	}

	// Use this for initialization
	void Update () {
		if (exploded)
			return;
		if (lifeTime < 0) {
			exploded = true;
			rb2d.velocity = new Vector3(0,0,0);
			anim.SetTrigger ("Explode");
			return;
		}
		lifeTime -= Time.deltaTime;
		rb2d.velocity = targetDirection * moveSpeed;
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Enemy")
			return;
		rb2d.velocity = new Vector3(0,0,0);
		anim.SetTrigger ("Explode");

		if (other.name == "Player" && !exploded) {
			HealthManager.HurtPlayer (damageToGive);
			//Destroy (other.gameObject);
		}
		exploded = true;
	}

	public void removeBlast(){
		Destroy (gameObject);
	}
}
