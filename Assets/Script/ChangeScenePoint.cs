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
        _changeScene = GameObject.FindWithTag("ChangeScene").GetComponent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (_changeScene.enabled)
            { _changeScene.StartFade(); }
            else
            { _flowchart.ExecuteBlock("can'tChangeScene"); }
        }
    }

    void ChangeScenePointUnlock()
    {
        _changeScene.enabled = true;
    }
}