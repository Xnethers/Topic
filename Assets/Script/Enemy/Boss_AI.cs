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
        //音波
        //月牙天沖
        //甩衝擊波下來-主角攻擊一定時間減弱（30% 5秒）
        //殘血大招：召喚小怪（3-4隻）
    }

    public Boss_Statement boss_Statement;//Boss當前狀態

    public GameObject _player;

    skill_list boss_skill;
    public int _distance; //與玩家距離

    public Enemy_Health boss_health;
    bool is_move;




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

    void Movement()
    {
        is_move = Physics.CheckSphere(transform.position, _distance, 1 << LayerMask.NameToLayer("Player"));
        if (is_move)
        { transform.position = Vector3.Lerp(transform.position, _player.transform.position, Time.deltaTime); }
        else
        { }
    }

    void Attack()
    {
		switch (boss_skill)
        {
            case skill_list.Move:
                {
                    break;
                }
            case skill_list.Attack:
                {
                    break;
                }
            case skill_list.Dead:
                {
                    break;
                }

        }

    }

    void Dead()
    { }


}