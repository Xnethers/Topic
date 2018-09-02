using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_target : MonoBehaviour
{
    public static Transform _target;

    public Image health_Bar;

    int i;

    GameObject g_target;
    public Enemy_Health _Health;


    // Use this for initialization
    void Start()
    {
        //g_target = _target.GetComponent<GameObject>();
        health_Bar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            _Health = _target.GetComponentInParent<Enemy_Health>();
            if (_Health)
            {
                health_Bar.fillAmount = _Health._health / _Health.max_health;
                health_Bar.enabled = true;
            }
        }
        else
        {
            Player_State.islock = false;
            health_Bar.fillAmount = 1;
            health_Bar.enabled = false;
        }
    }
}
