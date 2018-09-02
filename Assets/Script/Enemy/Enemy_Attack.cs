using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{

    public float Damage;
    float _time;

    private Thrower _thrower;

    private Strike _strike;

    // Use this for initialization
    void Start()
    {    }

    // Update is called once per frame
    void Update()
    {
        _thrower = GetComponent<Thrower>();
        _strike = GetComponent<Strike>();
    }

    public void attack(int i)
    {
        if (i == 1)//遠
        {
            if (_thrower != null)
                _thrower.enabled = true;
        }
        if (i == 2)//近
        {
            if (_strike != null)
                _strike.enabled = true;
        }
        if (i == 0)
        {
            if (_thrower != null)
                _thrower.enabled = false;
            if (_strike != null)
                _strike.enabled = false;
            _thrower.reset();
        }

    }
}
