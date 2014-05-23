using UnityEngine;
using System.Collections;

public class changeRockPos : MonoBehaviour {
	public float posY;
	// Use this for initialization
	void Start () {
		posY = 0.01f;
	}
	
	void Update()
	{
		// Widen the object by 0.1
		transform.position = new Vector3(transform.position.x, posY, transform.position.z);
	}
}
