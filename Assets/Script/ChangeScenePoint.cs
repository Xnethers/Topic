using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class ChangeScenePoint : MonoBehaviour
{

    public ChangeScene _changeScene;
    private Flowchart _flowchart;

    // Use this for initialization
    void Start()
    {
        _changeScene = GameObject.FindGameObjectWithTag("GameController").GetComponent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_changeScene.enabled)
            { _changeScene.Change_scene(_changeScene._scene); }
            else
            { _flowchart.ExecuteBlock("can'tChangeScene"); }
        }
    }

    void ChangeScenePointUnlock()
    {
        _changeScene.enabled = true;
    }
}