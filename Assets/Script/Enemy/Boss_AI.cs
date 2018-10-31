using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_AI : MonoBehaviour
{
    public enum Boss_Statement
    {
        Idle,
        Move,
        Attack,
        Fly,
        Dead
    }


    public enum skill_list
    {
        noisewave,//音波
        sniper,//月牙天沖
        shockwave,//甩衝擊波下來-主角攻擊一定時間減弱（30% 5秒）
        summon//殘血大招：召喚小怪（3-4隻）
    }

    public Boss_Statement boss_Statement;//Boss當前狀態

    [SerializeField] skill_list boss_skill;
    [SerializeField] GameObject _player;

    //public int _distance; //與玩家距離

    public Animator _animator;

    public Enemy_Health boss_health;
    bool can_attack;

    [SerializeField]
    int _delaytime;
    [SerializeField]
    int flyhight = 5;
    [SerializeField]
    bool is_fly;

    //技能
    noisewave _noisewave;
    summon _summon;
    shock_wave _shockwave;
    sniper _sniper;




    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        boss_health = GetComponent<Enemy_Health>();
        _animator = GetComponentInChildren<Animator>();
        //技能
        _noisewave = GetComponentInChildren<noisewave>();
        _summon = GetComponentInChildren<summon>();
        _shockwave = GetComponentInChildren<shock_wave>();
        _sniper = GetComponentInChildren<sniper>();
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
                    switch (boss_skill)
                    {
                        case skill_list.noisewave://音波
                            {
                               StartCoroutine(useskill(_noisewave, skill_list.sniper));
                                break;
                            }
                        case skill_list.sniper://月牙天沖
                            {
                                StartCoroutine(useskill(_sniper, skill_list.shockwave));
                                break;
                            }
                        case skill_list.shockwave://甩衝擊波下來-主角攻擊一定時間減弱（30% 5秒）
                            {
                                //useskill(_shockwave, skill_list.shockwave);
                                StartCoroutine(flyanition(_delaytime));
                                boss_Statement = Boss_Statement.Fly;
                                break;
                            }
                        case skill_list.summon://殘血大招：召喚小怪（3-4隻）
                            {
                                StartCoroutine(useskill(_summon, skill_list.shockwave));
                                useskill(_summon, skill_list.shockwave);
                                break;
                            }

                    }
                    break;
                }
            case Boss_Statement.Fly:
                {
                    break;
                }
            case Boss_Statement.Dead:
                {
                    dead();
                    break;
                }
        }
    }
    /*
    if(boss_skill == skill_list.noisewave)
    {
     _noisewave.useNoisewave();
     delay(5s)
     boss_skill = skill_list.sniper;
    }
     */

    void dead()
    {
        _animator.Play("M_die");
        boss_health._health = 0;

        if (boss_health._health == 0)
        {
            ParticleSystem _dieparticle = (ParticleSystem)Instantiate(boss_health.Die_particle, transform);
            _dieparticle.Play();
            Destroy(this.gameObject, boss_health.Die_time);
            //Destroy(eHP._fall, eHP.Die_time);
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

    IEnumerator useskill(SkillBasicData skill, skill_list next)
    {
        skill.UseSkill();
        yield return new WaitForSeconds(_delaytime);
        boss_skill = next;
    }

    IEnumerator delay(float delaytime)
    {
        yield return new WaitForSeconds(delaytime);

    }

    IEnumerator flyanition(float delaytime)
    {
        if (is_fly)
        {
            Vector3 flyposition = transform.position - new Vector3(0, flyhight, 0);
            transform.position = Vector3.Lerp(transform.position, flyposition, Time.deltaTime);
        }
        else
        {
            Vector3 flyposition = transform.position + new Vector3(0, flyhight, 0);
            transform.position = Vector3.Lerp(transform.position, flyposition, Time.deltaTime);
        }
        _shockwave.UseSkill();
        yield return new WaitForSeconds(delaytime);
        is_fly = !is_fly;
        boss_Statement = Boss_Statement.Fly;
    }

}