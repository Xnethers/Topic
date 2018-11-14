using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class claw : SkillBasicData
{
    public GameObject[] P_claw;//宣告投射物
    public float interval = 0.25f;//宣告子彈間隔時間

    [SerializeField] bool shot;
    [SerializeField] int count = 0; //子彈數
    [SerializeField] private int angle;//攻擊角度
    int i = 0;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug
        if (Input.GetKeyDown(KeyCode.C)) { UseSkill(); shot = true; }
        //

        if (CanUseSkill && isUse)
        {
            _animator.Play("claw");
            if (shot && i < count)
            {
                GameObject bullet = Instantiate(P_claw[i], transform.position, transform.rotation);
                i++;
                if (i != count)
                    StartCoroutine(timer());
                else
                {
                    StartCD();
                    i = 0;
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
    }

}