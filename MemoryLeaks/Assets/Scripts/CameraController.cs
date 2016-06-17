using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private PlayerController player;
	public bool isFollowing = true;

	private Vector3 target;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;

	public float xOffset;
	public float yOffset;

	public bool levelPreview;
	public float levelPreviewSmooth = 7f;
	public float previewCamSize = 15;
	public Transform levelDemoStartTarget;
	public Transform levelDemoEndTarget;

	public float xLevelBoundaryMin = -10000;
	public float xLevelBoundaryMax = 10000;
	public float yLevelBoundaryMin = -10000;
	public float yLevelBoundaryMax = 10000;

	private Camera cam;
	private float camSizeStore;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
		camSizeStore = cam.orthographicSize;
		player = FindObjectOfType<PlayerController>();
		if (isFollowing) {
			target = player.transform.position;
		} else {
			target = transform.position;
		}

		if(levelPreview){
			transform.position = levelDemoStartTarget.position;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (isFollowing) {
			//Get the players position and remove the z component. Also apply offset
			target = player.transform.position;
			target.z = transform.position.z;
			target.x += xOffset;
			target.y += yOffset;

			//Apply camera position restrictions
			if (target.x > xLevelBoundaryMax) {
				target.x = xLevelBoundaryMax;
			}
			if (target.x < xLevelBoundaryMin) {
				target.x = xLevelBoundaryMin;
			}
			if (target.y > yLevelBoundaryMax) {
				target.y = yLevelBoundaryMax;
			}
			if (target.y < yLevelBoundaryMin) {
				target.y = yLevelBoundaryMin;
			}

		}



		if (transform.position != target && !levelPreview) {
			transform.position = Vector3.SmoothDamp (transform.position, target, ref velocity, smoothTime);
		} 

		if(levelPreview){
			cam.orthographicSize = previewCamSize;
			if (transform.position != levelDemoEndTarget.position) {
				transform.position = Vector3.MoveTowards (transform.position, levelDemoEndTarget.position, levelPreviewSmooth * Time.deltaTime);
			} else {
				transform.position = levelDemoStartTarget.position;
				levelPreview = false;
				isFollowing = true;
			}
		}
		if (!levelPreview) {
			cam.orthographicSize = camSizeStore;
		}

	}
}
