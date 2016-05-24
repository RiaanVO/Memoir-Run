using UnityEngine;
using System.Collections;

public class Platforms : RaycastController
{
    /*
    public LayerMask platformCollision;
    public Vector3 move;

    // Use this for initialization
    public override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = move * Time.deltaTime;
        transform.Translate(velocity);
    }

    void MovePassengers(Vector3 velocity)
    {
        float rayLength = Mathf.Abs(velocity.y + skinWidth);
        float directionX = Mathf.Sign(velocity.x);
        float directionY = Mathf.Sign(velocity.y);

        //horizontal platform
        if (velocity.x != 0)
        {

        }

        //vert platform
        if (velocity.y != 0)
        {
            for (int i = 0; i < verticalRayCount; i++)
            {
                Vector2 rayOrigin;
                if (directionY == -1)
                {
                    rayOrigin = raycastOrigin.bottomLeft;
                }
                else
                {
                    rayOrigin = raycastOrigin.topLeft;
                }

                rayOrigin += Vector2.right * (verticalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, platformCollision);
                if (hit)
                {
                    float pushX = 0;
                    float pushY = (velocity.y - hit.distance - skinWidth) * directionY;
                    if (directionY == 1)
                    {
                        pushX = velocity.x;
                    }
                    else
                    {
                        pushX = 0;
                    }
                    hit.transform.Translate(new Vector3(pushX, pushY));
                }
            }
        }
    }*/
}

