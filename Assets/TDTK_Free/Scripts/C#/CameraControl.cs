using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	/// <summary>
	/// The speed at which the camera pans.
	/// </summary>
	public float panSpeed = 5;

	/// <summary>
	/// The speed at which the camera zooms.
	/// </summary>
	public float zoomSpeed = 5;

	/// <summary>
	/// The minimum x position of the camera bounds.
	/// </summary>
	public float minPosX = -10;

	/// <summary>
	/// The maximum x position of the camera bounds.
	/// </summary>
	public float maxPosX = 10;

	/// <summary>
	/// The minimum z position of the camera bounds.
	/// </summary>
	public float minPosZ = -10;

	/// <summary>
	/// The maximum z position of the camera bounds.
	/// </summary>
	public float maxPosZ = 10;

	/// <summary>
	/// The minimum zoom of the camera.
	/// </summary>
	public float minZoom = 8;

	/// <summary>
	/// The maximum zoom of the camera.
	/// </summary>
	public float maxZoom = 30;

	// Update is called once per frame
	void Update () {

		// Scale delta time using timescale
		float deltaT = Time.deltaTime;

		if (Time.timeScale != 1) {
			deltaT /= Time.timeScale;
		}
		
		#if UNITY_EDITOR || (!UNITY_IPHONE && !UNITY_ANDROID)

		Transform cam = Camera.main.transform;

		// Keep movement relative to camera
		Quaternion direction = Quaternion.Euler(0, transform.eulerAngles.y, 0);

		if(Input.GetButton("Horizontal")) {
			Vector3 dir = transform.InverseTransformDirection(direction * Vector3.right);
			transform.Translate(dir * panSpeed * deltaT * Input.GetAxisRaw("Horizontal"));
		}

		if(Input.GetButton("Vertical")) {
			Vector3 dir = transform.InverseTransformDirection(direction * Vector3.forward);
			transform.Translate(dir * panSpeed * deltaT * Input.GetAxisRaw("Vertical"));
		}

		// Zooming
		float mouseScroll = Input.GetAxis("Mouse ScrollWheel");

		if (mouseScroll < 0 || mouseScroll > 0) {
			// Translate camera along zoom axis
			cam.Translate(cam.forward * zoomSpeed * mouseScroll, Space.World);

			// Clamp to min/max distance along zoom axis
			float zoomDistance = Vector3.Dot(cam.position - transform.position, cam.forward);

			if (zoomDistance > maxZoom) {
				cam.position = transform.position + cam.forward * maxZoom;
			}
			else if (zoomDistance < minZoom) {
				cam.position = transform.position + cam.forward * minZoom;
			}
		}
		
		#endif

		// Clamp x-z movement to bounding box
		float x = Mathf.Clamp(transform.position.x, minPosX, maxPosX);
		float z = Mathf.Clamp(transform.position.z, minPosZ, maxPosZ);
		
		transform.position = new Vector3(x, transform.position.y, z);
	}
	
	/// <summary>
	/// Show the bounds and zoom gizmo.
	/// </summary>
	public bool showGizmo = true;

	void OnDrawGizmos() {
		if (showGizmo) {
			Vector3 p1 = new Vector3(minPosX, transform.position.y, maxPosZ);
			Vector3 p2 = new Vector3(maxPosX, transform.position.y, maxPosZ);
			Vector3 p3 = new Vector3(maxPosX, transform.position.y, minPosZ);
			Vector3 p4 = new Vector3(minPosX, transform.position.y, minPosZ);
			
			Gizmos.color = Color.green;
			Gizmos.DrawLine(p1, p2);
			Gizmos.DrawLine(p2, p3);
			Gizmos.DrawLine(p3, p4);
			Gizmos.DrawLine(p4, p1);

			Gizmos.color = Color.blue;
			Gizmos.DrawLine(transform.position + Camera.main.transform.forward * minZoom, transform.position + Camera.main.transform.forward * maxZoom);
		}
	}
	
}
