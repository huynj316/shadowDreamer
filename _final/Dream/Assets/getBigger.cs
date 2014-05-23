using UnityEngine;
using System.Collections;

public class getBigger : MonoBehaviour {
	public float scale;
	// Use this for initialization
	void Start () {
		scale = 0.02f;
	}
	
	void Update()
	{
		// Widen the object by 0.1
		transform.localScale = new Vector3(scale, scale, scale);
//		pos = speed * Time.deltaTime;
//		transform.position = transform.position + transform.forward * speed * Time.deltaTime;
		//I don't recall if "transform.position += something", if not,
		//user "transform.position = transform.position + something"
	}
}
