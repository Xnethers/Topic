using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Boss_AI : MonoBehaviour
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
    [SerializeField] bool is_fly; //是否懸空

    //技能
    noisewave _noisewave;
    summon _summon;
    shock_wave _shockwave;
    sniper _sniper;
    claw _claw;

    // Use this for initialization

    void Awake()
    {

    }
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
        _claw = GetComponentInChildren<claw>();

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
                    if (boss_Statement == Boss_Statement.Move)
                    {
                        a = StartCoroutine(flyanition());
                    }
                    break;
                }
            case Boss_Statement.Isground:
                {
                    if (boss_Statement == Boss_Statement.Isground)
                    {
                        a = StartCoroutine(groundAttack());
                    }
                    break;
                }
            case Boss_Statement.IsFly:
                {
                    if (boss_Statement == Boss_Statement.IsFly)
                    {
                        a = StartCoroutine(flyAttack());
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

    void Movement(int d)
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
                /* 
                switch (k)
                {
                    case 1:
                        { yield return new WaitForSeconds(3); _claw.UseSkill(); k++; }
                        break;

                    case 2:
                        { yield return new WaitForSeconds(3); _shockwave.UseSkill(); k++; }
                        break;

                    case 3:
                        { yield return new WaitForSeconds(3); boss_Statement = Boss_Statement.Move; k = 0; }
                        break;
                }
                */
                /*
                _sniper.UseSkill();
                yield return new WaitForSeconds(8);
                yield return new WaitForSeconds(2);
                _noisewave.UseSkill();
                yield return new WaitForSeconds(2);
                yield return new WaitForSeconds(2);
                boss_Statement = Boss_Statement.Move;
                */
            }
            else
            {
                StopCoroutine(a);
                yield return null;
            }
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
                    case 1:
                        { yield return new WaitForSeconds(3); _claw.UseSkill(); k++; }
                        break;

                    case 2:
                        { yield return new WaitForSeconds(3); _shockwave.UseSkill(); k++; }
                        break;

                    case 3:
                        { yield return new WaitForSeconds(3); _summon.UseSkill(); k++; }
                        break;

                    case 4:
                        { yield return new WaitForSeconds(3); _sniper.UseSkill(); k++; }
                        break;

                    case 5:
                        { yield return new WaitForSeconds(3); _noisewave.UseSkill(); k++; }
                        break;

                    case 6:
                        { yield return new WaitForSeconds(3); boss_Statement = Boss_Statement.Move; }
                        break;

                }
                /*
                _shockwave.UseSkill();
                yield return new WaitForSeconds(3);
                _summon.UseSkill();
                yield return new WaitForSeconds(10);
                _sniper.UseSkill();
                yield return new WaitForSeconds(3);
                _sniper.UseSkill();
                yield return new WaitForSeconds(3);
                _sniper.UseSkill();
                yield return new WaitForSeconds(3);
                _noisewave.UseSkill();
                yield return new WaitForSeconds(3);
                 */
            }
            else
            {
                StopCoroutine(a);
                k = 0;
                yield return null;
            }
        }
    }
    IEnumerator flyanition()
    {
        if (boss_Statement == Boss_Statement.Move)
        {
            _animator.SetBool("isfly", true);
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
            yield return new WaitForSeconds(2f);
            is_fly = !is_fly;
            _animator.SetBool("isfly", false);
            yield return null;
            if (!is_fly)
            { boss_Statement = Boss_Statement.Isground; }
            else
            { boss_Statement = Boss_Statement.IsFly; }
            yield break;
        }
        else
        {
            StopCoroutine(a);
            yield return null;
        }


    }
}