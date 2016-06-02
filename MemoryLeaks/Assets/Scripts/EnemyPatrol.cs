using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public LayerMask whatIsWall;
	private bool hittingWall = false;

	public Transform edgeCheck;
	private bool atEdge = false;

	private Rigidbody2D rb2d;

	public GameObject memoryPickup;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (hittingWall || atEdge) {
			moveRight = !moveRight;
			transform.localScale = new Vector3 (transform.localScale.x * -1, 1, 1);
		}

		if (moveRight) {
			rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);
		} else {
			rb2d.velocity = new Vector2 (-moveSpeed, rb2d.velocity.y);
		}
	}

	void FixedUpdate(){
		hittingWall = Physics2D.Linecast (transform.position, wallCheck.position, whatIsWall);
		atEdge = !Physics2D.Linecast (transform.position, edgeCheck.position, whatIsWall);

	}
}
