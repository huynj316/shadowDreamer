using UnityEngine;
using System.Collections;

public class moveTreesUp : MonoBehaviour {
	public float startPosY;
	public float endPosY;
	public float speedY;
	// Use this for initialization
	void Start () {
		startPosY = -2.5f;
		endPosY = 1.6f;
		speedY = 0.01f;
		transform.position = new Vector3(transform.position.x, startPosY, transform.position.z);
	}
//	1.56
	void Update()
	{
		if (transform.position.y < endPosY) {
			transform.position = new Vector3(transform.position.x, transform.position.y + speedY, transform.position.z);
		}
	}
}
