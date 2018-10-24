using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class NPC : MonoBehaviour
{

    public Flowchart _flowchart;
    private bool hit = false;
    public int distance = 3;

    //private Outline _outline;

    public bool is_talk;

    // Use this for initialization
    void Start()
    {

        _flowchart = GameObject.FindObjectOfType<Flowchart>();
        //_outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {

        if (hit)
        {
            if (Input.GetKeyDown(KeyCode.F))
            { is_talk = true; }
        }
    }

    
    /* 
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
        }*/
}
