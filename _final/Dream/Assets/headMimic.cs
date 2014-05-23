using UnityEngine;
using System.Collections;

public class headMimic: MonoBehaviour {
	Vector3 offset;
	
	void Start() {
		GameObject masterN = GameObject.Find("Neck");
		offset = masterN.transform.position - transform.position;
	}
	
	void Update () {
		GameObject masterN = GameObject.Find("Neck");
		transform.position = masterN.transform.position - offset;
		transform.rotation = masterN.transform.rotation;
	}

}
