using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{

    public AnimationClip _ani;
    [SerializeField] private float ani_time;
    private ChangeScene _cs;

    // Use this for initialization
    void Start()
    {
        ani_time = _ani.length;
        _cs = GetComponent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        ani_time -= Time.deltaTime;
        if (ani_time <= 0)
        { _cs.Start_game(); }
    }
}
