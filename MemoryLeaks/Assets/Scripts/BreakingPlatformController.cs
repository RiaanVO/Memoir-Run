using UnityEngine;
using System.Collections;

public class BreakingPlatformController : MonoBehaviour {

	public float breakDelay;
	private float breakDelayCounter;
	public float reapearDelay;
	private float reapearDelayCounter;

	private bool broken = false;
	private bool breaking = false;
	private bool playerTouched = false;

	private Animator anim;
	private BoxCollider2D bc2d;
	private SpriteRenderer spriteRenderer;



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		bc2d = GetComponent<BoxCollider2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();

		breakDelayCounter = breakDelay;
		reapearDelayCounter = reapearDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTouched) {
			if (breakDelayCounter > 0) {
				breakDelayCounter -= Time.deltaTime;
				return;
			} else {

				if (!broken) {
					broken = true;
					anim.SetTrigger("Break");
				}

				if (reapearDelayCounter > 0) {
					reapearDelayCounter -= Time.deltaTime;
					return;
				} else {
					broken = false;
					playerTouched = false;
					breaking = false;
					spriteRenderer.enabled = true;
					bc2d.enabled = true;
				}
			}
		}
	}

	public void hidePlatform(){
		spriteRenderer.enabled = false;
		bc2d.enabled = false;
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.transform.name == "Player" && !breaking) {
			playerTouched = true;
			breaking = true;
			anim.SetTrigger ("Crack");
			breakDelayCounter = breakDelay;
			reapearDelayCounter = reapearDelay;
		}
	}
}
