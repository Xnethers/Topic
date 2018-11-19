using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Levelup : MonoBehaviour
{
    public Image UI;
    public Flowchart _flowchart;
    public float distance;
    public SkillBasicData[] upskill;
    private Enemy_Health hp;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp._health <= 0)
        {

        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
        }
    }

    void levelup()
    {

    }
}
