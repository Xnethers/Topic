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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Player_target._target != null)
        {
            CanUseSkill = true;
            d = Vector3.Distance(transform.position, Player_target._target.position);
        }
        else
        { CanUseSkill = false; }

        if (Input.GetMouseButtonDown(0))
        {
            AddCombo();
            int _d = CalculateDamege();
            isUse = true;
            if (isUse && CanUseSkill && d < _distance)
            {
                Player_target._target.GetComponentInParent<Enemy_Health>()._health -= _d; //結算傷害
                Player_target._target.GetComponentInParent<AI>().isHurt = true;//打擊動畫
                show_damage(_d,Player_target._target.position);
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
