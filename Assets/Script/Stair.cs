using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour {

	private Player_State _playerState;

	// Use this for initialization
	void Start () {
		_playerState = GameObject.FindObjectOfType<Player_State>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        { _playerState.is_grounded = true; }
    }

    void OnTriggerExit(Collider other)

    {
        if (other.tag == "Player")
        { _playerState.is_grounded = false; }
    }
}
