using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroysword : MonoBehaviour
{
    [SerializeField] AnimationClip fairy_guide;
	float ani_time;

    // Use this for initialization
    void Start()
    {
        ani_time = fairy_guide.length;
    }

    // Update is called once per frame
    void Update()
    {
        ani_time -= Time.deltaTime;
        if (ani_time <= 0)
        { Destroy(this.gameObject); }
    }
}
