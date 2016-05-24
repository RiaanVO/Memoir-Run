using UnityEngine;
using System.Collections;

[RequireComponent(typeof (BoxCollider2D))]

public class Controller2D : MonoBehaviour {


    public Collision collision;
    public bool landed;
    BoxCollider2D collider;
    RaycastOrigin raycastOrigin;

    //comment this out to separate cto raycastcontroller
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;
    float horizontalRaySpacing;
    float verticalRaySpacing;
    const float skinWidth = .015f;
    public LayerMask obstacles;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        RaySpacing();
    }
    /* This is the start method once separated into raycast controller
    public override void Start()
    {
        base.Start();
    }
    */
    public void Move(Vector3 velocity)
    {
        UpdateRaycastOrigin();
        collision.Reset();

        if (velocity.x != 0)
        {
            HorizontalCollisions(ref velocity);
        }
        if (velocity.y != 0)
        {
            VerticalCollisions(ref velocity);
        }

        transform.Translate(velocity);
    }


    void VerticalCollisions(ref Vector3 velocity)
    {
        float directionY = Mathf.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y + skinWidth);


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

            rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, obstacles);

            Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.red);

            if(hit)
            {
                velocity.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;

                if (directionY == -1)
                {
                    collision.below = true;
                    landed = true;
                }
                else if (directionY == 1)
                {
                    collision.above = true;
					landed = false;
                }

            }
         }
    }

    void HorizontalCollisions(ref Vector3 velocity)
    {
        float directionX = Mathf.Sign(velocity.x);
        float rayLength = Mathf.Abs(velocity.x + skinWidth);


        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin;
            if (directionX == -1)
            {
                rayOrigin = raycastOrigin.bottomLeft;
            }
            else
            {
                rayOrigin = raycastOrigin.bottomRight;
            }

            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, obstacles);

            if (hit)
            {
                velocity.x = (hit.distance - skinWidth) * directionX;
                rayLength = hit.distance;

                if (directionX == -1)
                {
                    collision.left = true;
                }
                else if (directionX == 1)
                {
                    collision.right = true;
                }
            }
        }
    }

    void UpdateRaycastOrigin()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigin.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigin.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigin.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigin.topRight = new Vector2(bounds.max.x, bounds.min.y);
    }

    void RaySpacing()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);
        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        //finds spacing between two rays.
        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.y / (verticalRayCount - 1);

   
    }
    //comment out to move into raycast controller
    struct RaycastOrigin
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }

    public struct Collision
    {
        public bool above, below;
        public bool left, right;

        public void Reset()
        {
            above = false;
            below = false;
            left = false;
            right = false;
        }
    }
}
