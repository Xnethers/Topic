using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour {

	public Player_State _state;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void OnTriggerEnter(Collider other)
	 {
		 if (other.gameObject.tag == "Player")
		 {
			Player_State.isdebuff = true;
		 }
	 }
}
