using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_AI : MonoBehaviour
{
    public enum Boss_Statement
    {
        Move,
        Attack,
        Dead
    }

    enum skill_list
    {
        noisewave,//音波
        sniper,//月牙天沖
        shockwave,//甩衝擊波下來-主角攻擊一定時間減弱（30% 5秒）
        summon//殘血大招：召喚小怪（3-4隻）
    }

    public Boss_Statement boss_Statement;//Boss當前狀態

    public GameObject _player;

    skill_list boss_skill;
    //public int _distance; //與玩家距離

    public Enemy_Health boss_health;
    bool can_attack;

    [Header("技能1")]

    public int distance_1;

    [Header("技能2")]

    public int distance_2;

    [Header("技能3")]

    public int distance_3;




    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        boss_health = GetComponent<Enemy_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss_health._health <= 0)
        { boss_Statement = Boss_Statement.Dead; }

        switch (boss_Statement)
        {
            case Boss_Statement.Move:
                {
                    break;
                }
            case Boss_Statement.Attack:
                {
                    break;
                }
            case Boss_Statement.Dead:
                {
                    break;
                }
        }



    }

    void Movement(int d)
    {
        can_attack = Physics.CheckSphere(transform.position, d, 1 << LayerMask.NameToLayer("Player"));
        if (!can_attack)
        { transform.position = Vector3.Lerp(transform.position, _player.transform.position, Time.deltaTime); }
        else
        { }
    }

    void Attack()
    {
        float b_p_d = Vector3.Distance(transform.position, _player.transform.position);
        switch (boss_skill)
        {

            case skill_list.noisewave:
                {
                    
                        break;
                }
            case skill_list.sniper:
                {
                    break;
                }
            case skill_list.shockwave:
                {
                    break;
                }
            case skill_list.summon:
                {
                    break;
                }

        }

    }

    void Dead()
    { }


}