using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

	public int damageToGive;
	public bool hasAnimation;
	public string animationTrigger;
	public float xKnockbackAmount;
	public float yKnockbackAmount;
	public float knockbackDuration;
	private float direction;

	private Animator anim;

	// Use this for initialization
	void Start () {
		if (hasAnimation) {
			anim = GetComponent<Animator> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			if (hasAnimation) {
				anim.SetTrigger (animationTrigger);
			}

			if (transform.position.x > other.transform.position.x) {
				direction = -1;
			} else {
				direction = 1;
			}

			other.GetComponent<PlayerController> ().applyKnockback (new Vector2(direction * xKnockbackAmount, yKnockbackAmount), knockbackDuration);
			HealthManager.HurtPlayer (damageToGive);
		}
	}
}
