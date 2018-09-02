using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public Transform _target;
    Vector3 _ground = -Vector3.up;
    RaycastHit hit;
    float d;

    // Use this for initialization
    void Start()
    {
        //_ground = _target.position;
        Physics.Raycast(_target.position, _ground, out hit, 1 << LayerMask.NameToLayer("Ground"));
        d = _target.position.y - hit.distance * 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_target.position.x, d, _target.position.z);
        transform.rotation = _target.rotation;
    }
}
