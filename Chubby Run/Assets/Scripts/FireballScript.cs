using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour {

	// Use this for initialization
	public int Direction;
	public float timeleft;
	public AudioSource soundHit;
	private float speed;
	private int hit;
	private Animator animator;
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
		speed = 10.5f;
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
		this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		if (timeleft < 0)
			Destroy (this.gameObject);
		timeleft -= Time.deltaTime;
		if (hit > 0) {
			hit++;
			animator.SetBool ("Hit", true);
			if (hit == 30)
				Destroy (gameObject);
		} else {
			switch (Direction) {
			case 0:
				transform.Translate (Vector3.right * Time.deltaTime * speed);
				break;
			case 1:
				transform.Translate (Vector3.right * Time.deltaTime * speed);
				break;
			case 2:
				transform.Translate (Vector3.right * Time.deltaTime * speed);
				break;
			case 3:
				transform.Translate (Vector3.right * Time.deltaTime * speed);
				break;
			}
		}
	}
	void OnCollisionEnter(Collision c){
		hit = 1;
		animator.SetBool ("Hit", true);
		gameObject.GetComponent<BoxCollider> ().enabled = false;

		soundHit.Play ();
	}
}
