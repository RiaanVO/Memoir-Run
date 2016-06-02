using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;
	public GameObject deathEffect;
	public int memoriesOnDeath;
	public GameObject memoryPickup;
	public bool hasAnimation;
	public string animationTrigger;

	public bool isDead = false;
	private Animator anim;

	// Use this for initialization
	void Start () {
		if (hasAnimation)
			anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0 && !isDead) {
			if (deathEffect != null) {
				Instantiate (deathEffect, transform.position, transform.rotation);
			}
			for (int i = 1; i <= memoriesOnDeath; i++) {
				Instantiate (memoryPickup, transform.position, transform.rotation);
			}
			isDead = true;

			if (hasAnimation) {
				anim.SetTrigger (animationTrigger);
			} else {
				destroyEnemy ();
			}

		}
	}

	public void giveDamage(int damageToGive){
		enemyHealth -= damageToGive;
	}

	public bool getIsDead(){
		return isDead;
	}

	public void destroyEnemy(){
		Destroy (gameObject);
	}
}
