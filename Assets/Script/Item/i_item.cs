using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*附加腳本時自動生成元件*/
[RequireComponent(typeof(Collider))]

public class i_item : MonoBehaviour
{

    public string _name;
    public string _description;

    private bool hit = false;
    private int distance = 3;
    private Outline _outline;

    // Use this for initialization
    void Start()
    {
        _outline = GetComponent<Outline>();
        //_name = _key.name;
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics.CheckSphere(transform.position, distance, 1 << LayerMask.NameToLayer("Player"));

        if (!hit)
        { _outline.enabled = false; }
        else
        {
            _outline.enabled = true;
        }
    }
}
