using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraController : NetworkBehaviour {

	// Use this for initialization
	public GameObject player;
	private Vector3 offset;
	void Start () {
		offset = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		FollowPlayer ();
	}
	void FixedUpdate(){
	}
	void FollowPlayer(){
		float x = player.transform.position.x - 0.3f*player.transform.localScale.x+3.0f;
		float y = player.transform.position.y - 0.4f*player.transform.localScale.y+3.0f;
		float z = -19; 
		transform.position = new Vector3(x,y,z);
		//transform.Translate (player.transform.position.x - offset.x, player.transform.position.y - offset.y,0);
		//offset = player.transform.position;
	}
	void onGUI(){
	}
}
