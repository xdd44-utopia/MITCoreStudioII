using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCameraController : MonoBehaviour
{
	public Transform screen;
	private Camera cam;
	private float defaultW;
	private float defaultH;
	private float defaultZ;
	private float defaultHeight;
	private float defaultScreenZ;
	private float aspect;

	private Transform face;
	private const float sensitivity = 0.05f;

	private Vector3 targetPos;

	void Start()
	{
		cam = GetComponent<Camera>();
		defaultW = screen.transform.localScale.x * 5;
		defaultH = screen.transform.localScale.z * 5;
		defaultZ = transform.position.z - 100;
		aspect = defaultW / defaultH;
		defaultHeight = transform.position.y;
		defaultScreenZ = screen.position.z;
		targetPos = transform.position;
	}

	// Update is called once per frame
	void Update()
	{

		if (GameObject.Find("Face0") != null) {
			face = GameObject.Find("Face0").transform;
		}
		if (face != null) {
			targetPos= new Vector3(face.position.x * sensitivity, face.position.y * sensitivity + defaultHeight + 10f, defaultZ + 100 + (- 600 - face.position.z) * sensitivity);
		}
		transform.position = Vector3.Lerp(transform.position, targetPos, 0.5f);

		float dist = transform.position.z - defaultScreenZ - 100;
		float[] angles = new float[4];
		angles[0] = Mathf.Atan2((defaultW + transform.position.x) / aspect, dist) * 180 / Mathf.PI; //left
		angles[1] = Mathf.Atan2((defaultW - transform.position.x) / aspect, dist) * 180 / Mathf.PI; //right
		angles[2] = Mathf.Atan2(defaultH - (transform.position.y - defaultHeight), dist) * 180 / Mathf.PI; //up
		angles[3] = Mathf.Atan2(defaultH + (transform.position.y - defaultHeight), dist) * 180 / Mathf.PI; //down
		float fov = Mathf.Max(angles) * 2;
		cam.fieldOfView = fov;
		cam.nearClipPlane = dist - 0.05f;

		float scale = Mathf.Tan(fov * Mathf.PI / 360f) * dist / defaultH;
		screen.transform.localScale = new Vector3(scale * defaultH * aspect / 5, 1, scale * defaultH / 5);
		screen.transform.position = new Vector3(transform.position.x, (transform.position.y - defaultHeight) + defaultHeight, defaultScreenZ);
	}
}
