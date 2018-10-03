using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
    public AudioClip Sound;
    private float _damage;
    private Vector3 size = new Vector3(1, 1.6f, 1);
    private LayerMask player_layer;
    private bool is_attack;

    private float _animationtime;

    [Range(1, 5)]
    public float _timer;
    public float time;
    private Player_Health _playerhealth;
    private AI ai;


    // Use this for initialization
    void Start()
    {
        time = _timer;
        _damage = GetComponentInParent<Enemy_Attack>().Damage;
        ai =GetComponent<AI>();
        _animationtime = Animator.StringToHash("M_attack");// GetComponent<AnimatorStateInfo>().fullPathHash;
        player_layer = 1 << LayerMask.NameToLayer("Player");
        _playerhealth = GameObject.FindObjectOfType<Player_Health>();
        
    }

    // Update is called once per frame
    void Update()
    {
        is_attack = Physics.CheckSphere(transform.position, ai.attack_distance,  player_layer);
        if (is_attack)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                _playerhealth.NowHP -= _damage;
                Debug.Log("hit Player");
                GetComponent<AudioSource>().PlayOneShot(Sound);
                time = _timer;
            }
        }
    }
}
