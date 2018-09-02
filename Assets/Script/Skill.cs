using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Skill : MonoBehaviour
{
    public float _distance;
    public string skillName;//技能名称  
    [Header("放出次數")]
    public float _count;
    [Header("放出間隔")]
    public float _ru04ke6;
    [Header("傷害數值")]
    public float _damage;

    [Header("冷卻時間")]
    public float _coolingdown;
    [Header("技能UI")]
    public Sprite imagePath;

    bool k;
    float i = 0;
    void Start()
    {
    }

    void Update()
    {
        if (k)
            timer(_ru04ke6);

        if (i == _ru04ke6)
        {
            i = 0;
            k = false;
        }
    }

    void timer(float j)
    {
        i += Time.deltaTime;
        Debug.Log(i);
    }

    public void attack()
    {
        for (int i = 0; i < _count; )
        {
            if (!k)
            {
                Player_target._target.GetComponent<Enemy_Health>()._health -= _damage;
                k = true;
                i++;
            }
        }
    }
}

