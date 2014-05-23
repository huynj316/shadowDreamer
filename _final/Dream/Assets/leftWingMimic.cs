using UnityEngine;
using System.Collections;

public class leftWingMimic: MonoBehaviour {
	Vector3 offset;
//	Vector3 offsetLR;
	
	void Start() {
		GameObject masterL = GameObject.Find("LeftHand");
		offset = masterL.transform.position - transform.position;
//		offsetLR = masterL.transform.rotation - transform.rotation;
	}
	
	void Update () {
		GameObject masterL = GameObject.Find("LeftHand");
		transform.position = masterL.transform.position - offset;
		transform.rotation = masterL.transform.rotation;
	}
	
}
