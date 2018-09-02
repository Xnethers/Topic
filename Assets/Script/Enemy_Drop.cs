using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Drop : MonoBehaviour
{
    public GameObject e_attck;

    public float _timer;

    float re_timer;

    bool is_timer;


    // Use this for initialization
    void Start()
    {
        re_timer = _timer;
    }

    // Update is called once per frame
    void Update()
    {
        Drop();

        if (is_timer == true)
        {
            _timer = re_timer;
            _timer -= Time.deltaTime;
        }
    }

    public void Drop()
    {
        if (_timer <= 0)
        {
            is_timer = false;
            GameObject.Instantiate(e_attck, transform);
            //e_attck.transform.parent = null;
            //e_attck.transform.localPosition = Vector3.zero;
        }
    }
}
