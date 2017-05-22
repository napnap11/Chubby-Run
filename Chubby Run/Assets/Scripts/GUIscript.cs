using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GUIscript : MonoBehaviour {

	// Use this for initialization
	public Sprite skill;
	public Sprite[] skills;
	public Sprite[] skilllist;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int noPowerUp = PlayerPrefs.GetInt ("noPowerUp",0);
		for (int i = 0; i < noPowerUp; i++) {
			string power = PlayerPrefs.GetString ("PowerUp" + i.ToString ());
			switch (power) {
			case("Bigger"):
				skills [i] = skilllist [0];
				break;
			case("Fire"):
				skills [i] = skilllist [1];
				break;
			case("Speed"):
				skills [i] = skilllist [2];
				break;
			case("Banana"):
				skills [i] = skilllist [3];
				break;
			}
		}
	}
	void OnGUI(){
		GUIStyle style = new GUIStyle ();
		style.fontSize = 15;
		int noPowerUp = PlayerPrefs.GetInt ("noPowerUp",0);
		Rect srect1 = new Rect (Screen.width / 16, Screen.height * 7 / 8 - skill.rect.height/2f , skill.rect.width/2f , skill.rect.height/2f);
		GUI.Box(srect1,new Texture());
		style.fontSize = 24;
		if (noPowerUp > 0) {
			Sprite s = skills [0];
			Texture t = s.texture;
			Rect tr = s.textureRect;
			Rect r = new Rect (tr.x / t.width, tr.y / t.height, tr.width / t.width, tr.height / t.height);
			GUI.DrawTextureWithTexCoords (srect1, t, r);
		}
	}
}
