using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class FireballScript : NetworkBehaviour {

	// Use this for initialization
	[SyncVar]
	public int Direction;
	public AudioSource soundHit;
	private int hit;
	private Animator animator;
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
		if (Direction == 0)
			transform.rotation = new Quaternion(transform.rotation.x,transform.rotation.y,1,transform.rotation.w);
		if (Direction == 3) {
			transform.rotation = new Quaternion(transform.rotation.x,transform.rotation.y,100f,transform.rotation.w);
			gameObject.GetComponent<SpriteRenderer> ().flipY = true;
		}
		if (Direction == 2)
			transform.rotation = new Quaternion(transform.rotation.x,transform.rotation.y,-1,transform.rotation.w);
	}
	
	// Update is called once per frame
	void Update () {
		if (hit > 0) {
			hit++;
			animator.SetBool ("Hit", true);
			if (hit == 30)
				Destroy (gameObject);
		} 
	}
	void OnCollisionEnter(Collision c){
		hit = 1;
		animator.SetBool ("Hit", true);
		gameObject.GetComponent<BoxCollider> ().enabled = false;
		soundHit.Play ();
	}
}
