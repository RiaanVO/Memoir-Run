using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider2D))]
public class RaycastController : MonoBehaviour
{
    /*public LayerMask obstacles;

    [HideInInspector]
    float horizontalRaySpacing;
    [HideInInspector]
    float verticalRaySpacing;

    public RaycastOrigin raycastOrigin;
    [HideInInspector]
    public BoxCollider2D collider;
    public const float skinWidth = 0.01f;


    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;


    public virtual void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        RaySpacing();
    }

    public void UpdateRaycastOrigin()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigin.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigin.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigin.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigin.topRight = new Vector2(bounds.max.x, bounds.min.y);
    }

    public void RaySpacing()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);
        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        //finds spacing between two rays.
        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.y / (verticalRayCount - 1);


    }

    public struct RaycastOrigin
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
    }*/
}
