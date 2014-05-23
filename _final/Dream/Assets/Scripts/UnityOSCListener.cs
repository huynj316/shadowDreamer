

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnityOSCListener : MonoBehaviour  {

	public void OSCMessageReceived(OSC.NET.OSCMessage message){	
		string address = message.Address;
		ArrayList args = message.Values;

		float attention = float.Parse(args [0].ToString ());
		float meditation = float.Parse(args [1].ToString ());
		float blink = float.Parse(args [2].ToString ());

//		float newPos = mapRange(meditation, 0f , 100f, 0.01f, 0.3f);
//		Debug.Log(newPos);

//		GameObject thisObject = GameObject.Find ("RockGabriel");
//		thisObject.GetComponent<changeRockPos> ().posY = newPos;

		float intensity = meditation/10;
		GameObject light = GameObject.Find ("Directional light");
		light.GetComponent<changeLightIntensity> ().amplitude = intensity;

		if (attention > 80) {
			GameObject owl = GameObject.Find ("Soren");
			owl.GetComponent<moveForward> ().transform.position = owl.GetComponent<moveForward> ().initialPosition;
			owl.GetComponent<moveForward> ().startMoving = true;
		}


//		Debug.Log(address);
		for(int i = 0; i < args.Count; i++){
			Debug.Log(i + " : " + args[i]);
		}
		//		foreach( var item in args){
		//			Debug.Log(args.Count + ": " + item);
		//		}
	}

	public float mapRange(float value, float low1, float high1, float low2, float high2) {
		return low2 + (high2 - low2) * (value - low1) / (high1 - low1);
	}
}
