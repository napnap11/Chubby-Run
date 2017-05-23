using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class ChubbyBoyController : NetworkBehaviour {

	// Use this for initialization
	private float speed;
	private Animator animator;
	public GameObject boss;
	public GameObject Fireball;
	public GameObject Trap;
	private Vector3 defualtsize;
	private Color defualtcolor;
	[SyncVar]
	private int Bigging;
	[SyncVar]
	private int smalling;
	[SyncVar]
	private int done;
	[SyncVar]
	private int wait;
	[SyncVar]
	private int multi;
	[SyncVar]
	private Color color;
	public bool pause;
	void Start () {
		speed = 1.5f;
		PlayerPrefs.DeleteAll ();
		animator = this.GetComponent<Animator> ();
		defualtsize = this.gameObject.transform.localScale;
		defualtcolor = gameObject.GetComponent<SpriteRenderer> ().color;
		Bigging = 0;
		smalling = 0;
		done = 0;
		pause = false;
		wait =0;
		multi = 1;
		color = defualtcolor;
	}
	// Update is called once per frame
	void Update () {
		{
			if (animator.GetInteger ("Direction") == 3)
				this.GetComponent<SpriteRenderer> ().flipX = true;
			else
				this.GetComponent<SpriteRenderer> ().flipX = false;
			if (smalling != 0 || Bigging != 0 || wait != 0)
				Changesize ();
			if (done > 0) {
				done++;
				done %= 60;
			}
			this.GetComponent<SpriteRenderer> ().color = color;
			if (!isLocalPlayer)
				return;
			Move ();
			SkillCheck ();

		}
	}
	void Changesize(){
		if (smalling > 0) {
			if (transform.localScale.x > defualtsize.x)
				transform.localScale -= new Vector3 (2.5f, 2.5f, 0) * Time.deltaTime;
			else
				smalling = 0;
		}
		if (Bigging > 0 && smalling ==0) {
			transform.localScale += new Vector3 (2.5f, 2.5f, 0) * Time.deltaTime;
			if (++Bigging == 60){
				wait = 1;
				Bigging %= 60;
			}
		}
		if(wait>0){
			if (++wait == 240){
				CmdToNormal();

				wait %= 240;
			}
		}
	}
	void SkillCheck(){
		int noPowerUp = PlayerPrefs.GetInt ("noPowerUp",0);
		if (Input.GetKeyDown (KeyCode.Space) && noPowerUp > 0) { 
			CmdPowerUp (PlayerPrefs.GetString ("PowerUp0"));
			PlayerPrefs.SetInt ("noPowerUp", --noPowerUp);
			PlayerPrefs.SetString ("PowerUp0", PlayerPrefs.GetString ("PowerUp1", ""));
			PlayerPrefs.SetString ("PowerUp1", PlayerPrefs.GetString ("PowerUp2", ""));
			PlayerPrefs.Save();
		}
	}
	[Command]
	void CmdFire(){
		GameObject fireball = Instantiate (Fireball, this.transform.position, this.transform.rotation);
		if(animator.GetInteger("Direction")== 3)
		fireball.GetComponent<Rigidbody> ().velocity = Vector3.left * 10.5f;
		else fireball.GetComponent<Rigidbody> ().velocity = Vector3.right * 10.5f;
		fireball.GetComponent<FireballScript> ().Direction = animator.GetInteger("Direction");
		NetworkServer.Spawn (fireball);
		Destroy (fireball, 4.0f);
	}
	[Command]
	void CmdBanana(){
		GameObject trap = Instantiate (Trap, this.transform.position, this.transform.rotation);
		NetworkServer.Spawn (trap);
		Destroy (trap, 4.0f);
	}
	[Command]
	void CmdPowerUp(string powername){
		
		switch (powername) {
		case("Bigger"):
			Bigging = 1;
			break;
		case("Fire"):
			done = 1;
			CmdFire ();
			break;
		case("Speed"):
			multi = 4;
			wait = 1;
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			color = Color.red;
			break;
		case("Banana"):
			CmdBanana ();
		break;
		}

	}
	[Command]
	void CmdToNormal(){
		multi = 1;
		smalling = 1;
		gameObject.GetComponent<SpriteRenderer> ().color = defualtcolor;
		color = defualtcolor;
	}
	void Move(){
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), 0);
		if (move.x == 0 && move.y == 0)
			animator.SetBool ("Walking", false);
		else {
			if (Mathf.Abs (move.x) > Mathf.Abs (move.y)) {
				if (move.x < 0) {
					animator.SetInteger ("Direction", 3);
					this.GetComponent<SpriteRenderer> ().flipX = true;
				} else {
					animator.SetInteger ("Direction", 1);
					this.GetComponent<SpriteRenderer> ().flipX = false;
				}
			} else if (move.y	< 0) {
				animator.SetInteger ("Direction", 2);

			} else
				animator.SetInteger ("Direction", 0);
			animator.SetBool ("Walking", true);
		}
		if (Input.GetKey (KeyCode.Z)) {
			speed = 2.5f;
			animator.SetFloat ("speed", 1.5f);
		} else {
			speed = 1.5f;
			animator.SetFloat ("speed", 1f);
		}
		if (this.name == "Shadow") {
			Vector3 shadow = new Vector3 (boss.transform.position.x +0.234f, boss.transform.position.y - 0.934f);
			transform.position = shadow;
		}
		else if (move != Vector3.zero) transform.Translate (move * speed*multi / move.magnitude * Time.deltaTime);
		//gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}
	void OnCollisionStay(Collision c){
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			gameObject.GetComponent<Rigidbody> ().AddForce(Vector3.up*130*5,ForceMode.Impulse);
		}	
	}
}