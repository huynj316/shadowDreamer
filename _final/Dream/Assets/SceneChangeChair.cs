﻿using UnityEngine;
using System.Collections;

public class SceneChangeChair : MonoBehaviour {
	
	public Transform blueprint; //assign in inspector
	public GameObject putItHere;
	bool startChair;
	bool once;
	public AudioClip chair_fall;
	
	public static Collider collider1 = new Collider();
	
	// Use this for initialization
	void Start () {
		animation["ChairFall"].wrapMode = WrapMode.Once;
		startChair = false;
		once = true;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		//ray = an origin (vector3) and direction (vector3)
		
		Debug.Log ("raycasting is working");
		//Ray ray = Camera.main.ScreenPointToRay (new Vector3(640/2, 800/2));
		
		
		//Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);//(camera.pixelWidth / 2), (camera.pixelHeight / 2));//Input.mousePosition); //initialize ray 
		//Ray ray = transform.position;
		
		//Ray ray = Camera.main.ScreenPointToRay (Camera.main.transform.position);//(camera.pixelWidth / 2), (camera.pixelHeight / 2));//Input.mousePosition); //initialize ray 
		RaycastHit rayHit = new RaycastHit ();//blank container for info
		
		//actually shoot the raycast now
		
		//if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, 1000f))
		//if (Physics.Raycast (Camera.main.transform.position, out rayHit, 1000f))
		Debug.DrawRay (Camera.main.transform.position, Camera.main.transform.forward * 100f, Color.yellow);




		//if (Physics.Raycast (ray, out rayHit, 1000f))
		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out rayHit, 1000f))
		{
			//Debug.DrawRay(ray, Camera.main.transform.forward * rayHit.distance);
			Debug.Log("RAYCASTING");	
			collider1 = rayHit.collider;
			Debug.Log(collider1.name);

			
			
			if (collider1.name == "chair"){
				startChair = true;
				audio.PlayOneShot (chair_fall);
				
				Debug.Log ("this is when it would initiate box animation before transitioning");
				//Application.LoadLevel ("dancingBaby"); //dancingBaby as example of scene title
			} 
			
			if (startChair && once) {
				initChair();
				
			}
			//transform.LookAt(BoxCollider);// ( rayHit.point);
			/*
			if (Input.GetMouseButton (0)) {
				//Instantiate (blueprint, rayHit.point, Quaternion.identity); //quaternion.identity just turns into 0,0,0,0
			}
			if (Input.GetMouseButton (1) ) {
					Destroy (rayHit.transform.gameObject);
				}
				*/
		}
		
		
	}
	
	void initChair(){
		animation.Play("chair");
		//yield WaitForSeconds(1f);
		Debug.Log ("initChair is running");
		StartCoroutine (waiting());
		startChair = false;
		
		//rotate boxx y axis to face camera
		//transform up and towards the player
		
	}
	
	IEnumerator waiting(){
		Debug.Log ("waiting function");
		
		Application.LoadLevel ("Scene2");
		yield return new WaitForSeconds(putItHere.animation["chair"].length);
		once = false;
		putItHere.animation.Stop ("chair");
		//Application.LoadLevel ("Scene2");
		
	}
	
}
