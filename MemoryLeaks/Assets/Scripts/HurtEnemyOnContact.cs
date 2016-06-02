using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour {

	public int damageToGive;
	public bool playerFeedBack = false;

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			if (playerFeedBack && !other.GetComponent<EnemyHealthManager>().isDead)
				player.jump ();
			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
		}
	}
}
