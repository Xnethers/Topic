using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniper : SkillBasicData
{

    public GameObject P_sniper;//宣告投射物
    Transform Point;//宣告複製原點
    //public float Passtime = 0;//宣告經過時間
    public float interval = 0.25f;//宣告子彈間隔時間

    [SerializeField] bool shot;
    public int count = 0; //子彈數
    [SerializeField] private int angle;//攻擊角度
    int i = 0;

    float Q = 0;


    Quaternion rotation;


    // Use this for initialization
    void Start()
    {
        Q = -angle / 2;
        rotation = Quaternion.Euler(0, Q, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug
        if (Input.GetKeyDown(KeyCode.N)) { UseSkill(); shot = true; Point = this.transform; }
        //

        if (CanUseSkill && isUse)
        {
            _animator.Play("sniper");
            if (shot && i < count)
            {
                rotation = Quaternion.Euler(0, Q, 0);
                GameObject bullet = Instantiate(P_sniper, transform.position, transform.rotation * rotation);
                i++;
                if (i != count)
                    StartCoroutine(timer());
                else
                {
                    StartCD();
                    i = 0;
                    Q = -angle / 2; ;
                    isAnimation = false;
                }
            }
        }
        //進入CD
        CDing();
    }

    IEnumerator timer()
    {
        shot = false;
        yield return new WaitForSeconds(interval);
        shot = true;
        Q += angle / 4;
    }
}
