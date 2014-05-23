using UnityEngine;
using System.Collections;

public class moveForward : MonoBehaviour {
	public float speed;
	public float pos;
	public bool startMoving;

	public Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		speed = 2.0f;
		startMoving = false;
		initialPosition = transform.position;
	}
	
	void Update()
	{
		if (startMoving) {
			pos = speed * Time.deltaTime;
			transform.position = transform.position + transform.forward * speed * Time.deltaTime;
		}
		//I don't recall if "transform.position += something", if not,
		//user "transform.position = transform.position + something"
	}
}
