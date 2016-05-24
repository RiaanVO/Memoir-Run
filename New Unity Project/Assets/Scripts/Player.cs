using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Controller2D))]
public class Player : MonoBehaviour {

	public Animator animator;

    public float moveSpeed = 5;
    public float gravity = -12;
    Vector3 velocity;
    public float jump = 10;
    float velocityXSmoothing;

    float accTimeAir = 0.1f;
    float accTimeGround = 0.05f;
    float accTimeIce = 0.2f;

	//public bool jumping = false;
	int jumpHash = Animator.StringToHash("jumping");
   

    Controller2D controller;
	// Use this for initialization
	void Awake () {
        controller = GetComponent<Controller2D>();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

        if (controller.collision.above || controller.collision.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown (KeyCode.Space) && controller.landed)
        {
			animator.SetTrigger (jumpHash);

            velocity.y = jump;
            controller.landed = false;
        }

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collision.below)?accTimeGround:accTimeAir);
		if (controller.landed) 
		{
			velocity.y = 0;
		} 
		else 
		{
			velocity.y += gravity * Time.deltaTime;
		}
        controller.Move (velocity * Time.deltaTime);
	}
}
