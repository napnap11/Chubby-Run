using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {

	// Use this for initialization
	private int noPowerUp;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){

		noPowerUp = PlayerPrefs.GetInt ("noPowerUp", 0);
		if (noPowerUp == 0) {
			int check = Random.Range (0, 4);
			Debug.Log (check);
			switch (check) {
			case 0:
				PlayerPrefs.SetString ("PowerUp" + noPowerUp, "Bigger");
				break;
			case 1:
				PlayerPrefs.SetString ("PowerUp" + noPowerUp, "Fire");
				break;
			case 2:
				PlayerPrefs.SetString ("PowerUp" + noPowerUp, "Speed");
				break;
			case 3:
				PlayerPrefs.SetString ("PowerUp" + noPowerUp, "Banana");
				break;
			}
			PlayerPrefs.SetInt ("noPowerUp", ++noPowerUp);
			PlayerPrefs.Save ();
		}
	}
}
