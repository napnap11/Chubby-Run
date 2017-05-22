using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

	// Use this for initialization
	public float timeleft;
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if (timeleft < 0)
			Destroy (this.gameObject);
		timeleft -= Time.deltaTime;
	}
	void OnCollisionEnter(Collision c){
		
	}
}
