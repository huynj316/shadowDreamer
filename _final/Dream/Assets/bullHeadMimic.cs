using UnityEngine;
using System.Collections;

public class bullHeadMimic: MonoBehaviour {
	Vector3 offset;
	
	void Start() {
		GameObject masterL = GameObject.Find("Neck");
		offset = masterL.transform.position - transform.position;
	}
	
	void Update () {
		GameObject masterL = GameObject.Find("Neck");
		transform.position = masterL.transform.position - offset;
		transform.rotation = masterL.transform.rotation;
	}

}
