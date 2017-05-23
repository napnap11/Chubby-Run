using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class myNetworkManager : NetworkManager {

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId){
		GameObject player = (GameObject)Instantiate (playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
		NetworkServer.AddPlayerForConnection (conn, player, playerControllerId);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
