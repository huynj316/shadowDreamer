using UnityEngine;
using System.Collections;

public class changeLightIntensity : MonoBehaviour {
	public float amplitude;
	// Use this for initialization
	void Start () {
		amplitude = 6f;
	}
	
	void Update()
	{
		light.intensity = amplitude;
	}
}
