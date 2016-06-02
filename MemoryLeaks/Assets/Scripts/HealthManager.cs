using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public static int playerHealth;
	public int StartingHealth;
	public int maxPlayerHealth;
	public bool isDead = false;

	public Slider healthBar;

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		if (StartingHealth == 0)
			StartingHealth = maxPlayerHealth;
		playerHealth = StartingHealth;
		healthBar.maxValue = maxPlayerHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth > maxPlayerHealth) {
			playerHealth = maxPlayerHealth;
		}
		if (playerHealth <= 0 && !isDead) {
			levelManager.RespawnPlayer ();
			isDead = true;
			playerHealth = 0;
		}

		healthBar.value = playerHealth;
	}

	public static void HurtPlayer(int damageToGive){
		playerHealth -= damageToGive;
	}

	public void fullHealth(){
		playerHealth = maxPlayerHealth;
		healthBar.value = playerHealth;
		isDead = false;
	}
}
