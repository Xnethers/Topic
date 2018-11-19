using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AI3 : MonoBehaviour
{
    public enum Boss_Statement
    {
        Isground,
        IsFly,
        Idle,
        Move,
        Dead
    }

    public Boss_Statement boss_Statement;//Boss當前狀態


    [SerializeField] GameObject _player;

    //public int _distance; //與玩家距離

    public Animator _animator;

    public Enemy_Health boss_health;
    bool can_attack;

    [SerializeField] int flyhight = 5;
    [SerializeField] bool isfly; //是否懸空
    [SerializeField] bool isswitch; //是否正在切換
    //技能
    noisewave _noisewave;
    summon _summon;
    shock_wave _shockwave;
    sniper _sniper;
    claw _claw;

    // Use this for initialization

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        boss_health = GetComponent<Enemy_Health>();
        _animator = GetComponentInChildren<Animator>();
        //技能
        _noisewave = GetComponentInChildren<noisewave>();
        _summon = GetComponentInChildren<summon>();
        _shockwave = GetComponentInChildren<shock_wave>();
        _sniper = GetComponentInChildren<sniper>();
        _claw = GetComponentInChildren<claw>();
    }
    void Start()
    {
        StartCoroutine(flyAttack());
        StartCoroutine(groundAttack());
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
        Debug.Log(boss_Statement);
        if (boss_health._health <= 0)
        {
            boss_Statement = Boss_Statement.Dead;
            ParticleSystem _dieparticle = (ParticleSystem)Instantiate(boss_health.Die_particle, transform);
            _dieparticle.Play();
        }
    }

    Coroutine a;

    void StateMachine()
    {
        switch (boss_Statement)
        {
            case Boss_Statement.Move:
                {
                    if (isfly)
                    {
                        Vector3 flyposition = transform.position - new Vector3(0, flyhight, 0);
                        transform.position = Vector3.Lerp(transform.position, flyposition, Time.deltaTime);
                        StartCoroutine(flyanition());
                        if (!isswitch)
                        {
                            k = 0;
                            _animator.SetBool("isfly", false);
                            isfly = false;
                            boss_Statement = Boss_Statement.Isground;
                            break;
                        }
                    }
                    else
                    {
                        Vector3 flyposition = transform.position + new Vector3(0, flyhight, 0);
                        transform.position = Vector3.Lerp(transform.position, flyposition, Time.deltaTime);
                        StartCoroutine(flyanition());
                        if (!isswitch)
                        {
                            k = 0;
                            _animator.SetBool("isfly", false);
                            isfly = true;
                            boss_Statement = Boss_Statement.IsFly;
                            break;
                        }
                    }
                    break;
                }
            case Boss_Statement.Isground:
                {
                    isfly = false;
                    if (isswitch)
                    {
                        boss_Statement = Boss_Statement.Move;
                    }
                    break;
                }
            case Boss_Statement.IsFly:
                {
                    isfly = true;
                    if (isswitch)
                    {
                        boss_Statement = Boss_Statement.Move;
                    }
                    break;
                }
            case Boss_Statement.Dead:
                {
                    dead();
                    break;
                }
        }
    }
    void dead()
    {
        _animator.Play("M_die");
        boss_health._health = 0;

        if (boss_health._health == 0)
        {
            Destroy(this.gameObject, boss_health.Die_time);
            //Destroy(eHP._fall, eHP.Die_time);
        }
    }

    void MovetoPlayer(int d)
    {
        can_attack = Physics.CheckSphere(transform.position, d, 1 << LayerMask.NameToLayer("Player"));
        if (!can_attack)
        { transform.position = Vector3.Lerp(transform.position, _player.transform.position, Time.deltaTime); }
        else
        { }
    }
    [SerializeField] int k = 0;
    IEnumerator flyAttack()
    {
        while (true)
        {
            if (boss_Statement == Boss_Statement.IsFly)
            {
                switch (k)
                {
                    case 0:
                        { _sniper.UseSkill(); k++; yield return new WaitForSeconds(3); }
                        break;

                    case 1:
                        { _sniper.UseSkill(); k++; yield return new WaitForSeconds(3); }
                        break;

                    case 2:
                        { _sniper.UseSkill(); k++; yield return new WaitForSeconds(3); }
                        break;

                    case 3:
                        { _noisewave.UseSkill(); k++; yield return new WaitForSeconds(3); }
                        break;

                    case 4:
                        { isswitch = true; yield return null; }
                        break;
                }
            }
            else
            { yield return null; }
        }
    }

    IEnumerator groundAttack()
    {
        while (true)
        {
            if (boss_Statement == Boss_Statement.Isground)
            {
                switch (k)
                {
                    case 0:
                        { _claw.UseSkill(); k++; yield return new WaitForSeconds(3); }
                        break;

                    case 1:
                        { _shockwave.UseSkill(); k++; yield return new WaitForSeconds(3); }
                        break;

                    case 2:
                        { _summon.UseSkill(); k++; yield return new WaitForSeconds(10); }
                        break;

                    case 3:
                        { _sniper.UseSkill(); k++; yield return new WaitForSeconds(3); }
                        break;

                    case 4:
                        { _noisewave.UseSkill(); k++; yield return new WaitForSeconds(3); }
                        break;

                    case 5:
                        { isswitch = true; yield return null; }
                        break;
                }
            }
            else
            { yield return null; }
        }
    }


    IEnumerator flyanition()
    {
        yield return new WaitForSeconds(2);
        isswitch = false;
    }
}
