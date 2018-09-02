using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smooth : MonoBehaviour
{
    public Transform FollowTarget;
    public float Radius = 3.0f;
    public float Smooth = 2.0f;

    private Transform myTransform;

    float d;

    // Use this for initialization
    void Start()
    {
        if (!FollowTarget)
        { this.enabled = false; }

    }

    // Update is called once per frame
    void Update()
    {
        d = Vector3.Distance(transform.position, FollowTarget.position);
        if (CheckMargin())
        { transform.position = Vector3.Lerp(transform.position, FollowTarget.position, Smooth * Time.deltaTime); }
    }

    bool CheckMargin()
    {
        if (d > Radius)
            return true;
        else
        {
            if (d == 0)
                return false;
            else return true;
        }
    }
}
