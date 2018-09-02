using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class NPC : MonoBehaviour
{

    public Flowchart _flowchart;

    public string NPC_number;
    private Transform _player;
    private bool hit = false;
    public int distance = 3;

    private Outline _outline;

    public bool is_talk;

    // Use this for initialization
    void Start()
    {

        _flowchart = GameObject.FindObjectOfType<Flowchart>();
        _outline = GetComponent<Outline>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics.CheckSphere(transform.position, distance, 1 << LayerMask.NameToLayer("Player"));
        outline();
        talk();
    }

    void talk()
    {
        if (is_talk)
        {
            _flowchart.ExecuteBlock(NPC_number);
            is_talk = false;
        }
    }

    void outline()
    {
        if (hit)
        {
            _outline.enabled = true;
            if (Input.GetKeyDown(KeyCode.F))
            { is_talk = true; }
        }
        else
        { _outline.enabled = false; }
    }
}
