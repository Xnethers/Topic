using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class dooropen_ani : MonoBehaviour
{
    public bool islock;
    [Header("Box")]
    public Vector3 Scale = new Vector3(2, 3, 2);
    public Vector3 Center = new Vector3(-0.8f, 2.0f, 0);

    private Animator _animator;
    public bool can_open;

    // Use this for initialization
    void Start()
    { _animator = GetComponent<Animator>(); }

    // Update is called once per frame
    void Update()
    {
        if (islock)
        { }
        else
        { open(); }
    }

    void open()
    {
        can_open = Physics.CheckBox(transform.position + Center, Scale, Quaternion.identity, 1 << LayerMask.NameToLayer("Player"));
        if (can_open)
        { _animator.SetBool("open", true); }
        else
        { _animator.SetBool("open", false); }

    }
}
