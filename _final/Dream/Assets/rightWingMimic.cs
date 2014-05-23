using UnityEngine;
using System.Collections;

public class rightWingMimic: MonoBehaviour {
	Vector3 offset;
	//Quaternion rotation;
	//	Vector3 offsetLR;
	
	void Start() {
		GameObject masterR = GameObject.Find("RightHand");
		offset = masterR.transform.position - transform.position;
		//		offsetLR = masterL.transform.rotation - transform.rotation;
	}
	
	void Update () {
		GameObject masterR = GameObject.Find("RightHand");
		transform.position = masterR.transform.position - offset;
		transform.rotation = masterR.transform.rotation;

		//Debug.Log(transform.rotation);
	}
}
