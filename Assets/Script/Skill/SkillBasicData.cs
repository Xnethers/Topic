using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBasicData : MonoBehaviour
{
    public Sprite _sprite;
    public Animator _animator;
    public _PlayerMove _move;
    public float _distance;

    public GameObject PopupDamage;//傷害顯示

    [Header("技能等級")]
    public int level;

    [Header("冷卻時間")]
    public float CD;
    public float NowCD;
    [Header("消耗MP")]
    public int Cost;

    [Header("傷害數值")]
    public float Damage;

    [Header("控制接口")]
    public bool CanUseSkill = true;//可以使用此技能
    public bool isUse = false;//確認有使用技能

    public bool isAnimation = false;//是否在播放動畫 
    private Abilityvalue _ability;
    private UI_Damage Damage_UI;

    protected GameObject _player;
    private Player_Health HPMP ;

    void Awake()
    {
        NowCD = 0;
        _player = GameObject.FindWithTag("Player");
        _move = _player.GetComponent<_PlayerMove>();
        _animator = _player.GetComponentInChildren<Animator>();
        _ability = _player.GetComponentInChildren<Abilityvalue>();
        Damage_UI = FindObjectOfType<UI_Damage>();
        HPMP = _player.GetComponent<Player_Health>();
    }

    void Update()
    { }

    public void UseSkill()
    { isUse = true; isAnimation = true; }


    public void CostMP()
    { HPMP.NowMP -= Cost; }

    //計算傷害
    public int CalculateDamege()
    {
        float CountDamage = 0;//最終傷害
        //最終傷害 = 角色攻擊數值 * 技能倍率 * 亂數平衡值(%)
        CountDamage = (float)Damage * level * Random.Range(1, 101) / 100;
        //Debug.Log(CountDamage);
        //最低傷害1
        if (CountDamage <= 1)
        { CountDamage = 1; }
        //爆擊觸發 亂數0~99 < 角色爆擊值
        if (Random.Range(0, 100) < _ability.mCrit)
        {
            //爆擊 =  最終傷害 * 角色爆擊傷害%
            CountDamage *= _ability.mCritDamage / 100;
        }
        return (int)CountDamage;
    }

    public void show_damage(int damage , Vector3 _position)
    {
        GameObject mObject = (GameObject)Instantiate(PopupDamage, _position, Quaternion.identity);
        mObject.GetComponent<UI_Damage>().Value = (int)damage;
    }

    public void StartCD()
    { CanUseSkill = false; }
    public float GetCDFlaot()
    { return NowCD / CD; }

    public void CDing()
    {
        if (!CanUseSkill)
        {
            NowCD += Time.deltaTime;
            if (NowCD >= CD)
            {
                CanUseSkill = true;
                NowCD = 0;
            }
        }
    }

}

