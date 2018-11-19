using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TalktoNPC : MonoBehaviour {
    public bool is_talk;

    [Header("訊息")]
    public Flowchart _flowchart;

    //RaycastHit hit;
    [SerializeField]
    private Collider[] hit = new Collider[3];

    public float distance;
    [SerializeField]
    private Collider nearestobject;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Physics.OverlapSphereNonAlloc(transform.position, distance, hit, 1 << LayerMask.NameToLayer("Item"));
		
	}
}
