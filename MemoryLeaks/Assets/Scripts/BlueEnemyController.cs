using UnityEngine;
using System.Collections;

public class BlueEnemyController : MonoBehaviour {

	private bool playerInRange = false;
	private bool inLineOfSight = false;
	public float rangeRadius;
	public float shotDelay;
	private float shotDelayCounter;
	public LayerMask whatIsPlayer;

	public Transform firePoint;
	public GameObject enemyBlast;


	private Animator anim;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = FindObjectOfType<PlayerController> ();
	}
		
	void FixedUpdate(){
		if (playerInRange = Physics2D.OverlapCircle (transform.position, rangeRadius, whatIsPlayer)) {
			inLineOfSight = Physics2D.Linecast (new Vector2(firePoint.position.x, firePoint.position.y), new Vector2(player.transform.position.x, player.transform.position.y), whatIsPlayer);
		}
	}

	void Update () {
		if (playerInRange && inLineOfSight) {
			if (player.transform.position.x > transform.position.x) {
				transform.localScale = new Vector3 (1, 1, 1);
			} else {
				transform.localScale = new Vector3 (-1, 1, 1);
			}
			if (shotDelayCounter < 0) {
				anim.SetTrigger ("Shoot");
				shotDelayCounter = shotDelay;
			}
			shotDelayCounter -= Time.deltaTime;
		} else {
			shotDelayCounter = 0;
		}
	}

	public void Shoot(){
		Instantiate (enemyBlast, firePoint.position, firePoint.rotation);
	}
}
