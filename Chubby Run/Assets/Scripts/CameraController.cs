using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

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
		transform.Translate (player.transform.position.x - offset.x, player.transform.position.y - offset.y,0);
		offset = player.transform.position;
	}
	void onGUI(){
		GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a box");
	}
}
