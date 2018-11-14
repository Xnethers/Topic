using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : SkillBasicData
{

    public float ComboTime = 0.3f;

    private bool isComboTime = false;
    private float ComboTime_Time = 0;
    private bool istarget;
    float d;

    protected int Combo = 0;

    private int ComboLenth = 3;

    public List<GameObject> NA = new List<GameObject>();

    public List<GameObject> UPNA = new List<GameObject>();

    // Use this for initialization
    void Start()
    {

    }

    public override void UseSkill()
    {
        GameObject _na = (GameObject)Instantiate(NA[Combo], transform.position, transform.rotation);
        if (this.level == 2)
        { GameObject upna = (GameObject)Instantiate(UPNA[Combo], transform.position, transform.rotation); }
        AddCombo();
        int _d = CalculateDamege();
        isUse = true;
    }
    // Update is called once per frame
    void Update()
    {

        //進入CD
        CDing();

        if (CanUseSkill)
        {
            //show_damage(_d,Player_target._target.position);
            if (Input.GetMouseButtonDown(0))
            {
                UseSkill();
            }
        }

        switch (Combo)
        {
            case 1:
                {
                    _animator.Play("Nomal Attack");
                    isComboTime = true;
                    Player_State.ismove = false;
                }
                break;
            case 2:
                {
                    _animator.Play("Nomal Attack2");
                    isComboTime = true;
                    Player_State.ismove = false;
                }
                break;
            case 3:
                {
                    _animator.Play("Nomal Attack3");
                    isComboTime = true;
                    Player_State.ismove = false;
                }
                break;
        }


        //技能完畢後,可以在接續下段攻擊的時間
        if (isComboTime)
        {
            ComboTime_Time += Time.deltaTime;
            if (ComboTime_Time > ComboTime)
            {
                //Debug.Log("超出Combo時間,重製攻擊順序");
                StartCD();
                ResetCombo();
                isComboTime = false;
            }
        }

    }
    void AddCombo()
    {
        if (Combo < ComboLenth)
        {
            Combo++;
        }
        else
        {
            Combo = 1;
        }
        isComboTime = false;
        ComboTime_Time = 0;
    }

    //重製攻擊段數
    void ResetCombo()
    {
        Combo = 0;
        Player_State.ismove = true;
    }


}
