using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;
	private bool doubleJumped = false;

	public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool grounded = false;


	public Transform firePoint;
	public GameObject memoryBlast;
	public float shotDelay;
	private float shotDelayCounter;
	public int playerDamageOnShot;

	public GameObject punchObject;

	public int jumpDamageToGive;

	private float knockbackCount;
	private Vector2 knockbackAmount;
	private bool underKnockback = false;

	private Animator anim;
	private Rigidbody2D rb2d;

	//Ability fields
	public bool canDoubleJump;
	public bool canShoot;
	public bool canPunch;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, whatIsGround);
		Debug.DrawLine (transform.position, groundCheck.position);
		//Debug.Log (grounded);
	}

	// Update is called once per frame
	void Update () {
		checkMovement ();
		if (!underKnockback) {
			checkJump ();
			if (canShoot)
				checkShooting ();
			if (canPunch)
				checkPunch ();
		}
		//anim.SetBool ("underKnockback", underKnockback);
		checkFlip ();
	}

	private void checkPunch(){
		if (Input.GetButtonDown ("Fire2")) {
			anim.SetTrigger ("Punch");
		}
	}

	private void checkShooting(){
		//Check if the player is shooting, the animation will call the creation of the memory blast
		//Instantiate (memoryBlast, firePoint.position, firePoint.rotation);
		if (Input.GetButtonDown ("Fire1")) {
			anim.SetTrigger ("Shoot");
			shotDelayCounter = shotDelay;
		}

		if (Input.GetButton ("Fire1")) {
			shotDelayCounter -= Time.deltaTime;
			if (shotDelayCounter < 0) {
				anim.SetTrigger ("Shoot");
				shotDelayCounter = shotDelay;
			}
		}
	}

	public void fireMemoryBlast(){
		HealthManager.HurtPlayer (playerDamageOnShot);
		Instantiate (memoryBlast, firePoint.position, firePoint.rotation);
	}

	private void checkMovement (){
		if (underKnockback = (knockbackCount > 0)) {
			rb2d.velocity = knockbackAmount;
			knockbackCount -= Time.deltaTime;
		} else {
			rb2d.velocity = new Vector2 (moveSpeed * Input.GetAxisRaw("Horizontal"), rb2d.velocity.y);
			anim.SetFloat ("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
		}
		anim.SetBool ("knockedback", underKnockback);
	}

	public void applyKnockback(Vector2 amount, float time){
		knockbackAmount = amount;
		knockbackCount = time;
		underKnockback = true;
		anim.SetBool ("knockedback", underKnockback);
	}

	private void checkJump(){
		if (grounded) {
			doubleJumped = false;
		}

		if (Input.GetButtonDown ("Jump") && grounded) {
			jump ();
		}

		if (Input.GetButtonDown ("Jump") && !grounded && !doubleJumped && canDoubleJump) {
			jump ();
			doubleJumped = true;
		}
	}

	public void jump(){
		anim.SetTrigger ("Jump");
		rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpHeight);
	}

	private void checkFlip(){
		//Check if the players sprite is facing the right way
		if (underKnockback) {
			if (rb2d.velocity.x > 0) {
				transform.localScale = new Vector3 (-1, 1, 1);
			} else if (rb2d.velocity.x < 0) {
				transform.localScale = new Vector3 (1, 1, 1);
			}
		} else {
			if (rb2d.velocity.x > 0) {
				transform.localScale = new Vector3 (1, 1, 1);
			} else if (rb2d.velocity.x < 0) {
				transform.localScale = new Vector3 (-1, 1, 1);
			}
		}
	}

	public void respawnPlayer(){
		underKnockback = false;
		knockbackCount = 0;
		doubleJumped = true;
		GetComponent<HealthManager> ().fullHealth ();
	}

	/*
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy" && !grounded && !other.GetComponent<EnemyHealthManager>().isDead) {
			other.GetComponent<EnemyHealthManager> ().giveDamage (jumpDamageToGive);
			jump ();
		}
	} */
}
