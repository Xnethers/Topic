using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
    private float _damage;
    private Vector3 size = new Vector3(1, 1.6f, 1);
    private LayerMask player_layer;
    private bool is_attack;


    // Use this for initialization
    void Start()
    {
        _damage = GetComponentInParent<Enemy_Attack>().Damage;
        player_layer = 1 << LayerMask.NameToLayer("Player");
        if (is_attack)
        { StartCoroutine("Attack"); }
         else
        { StopCoroutine("Attack"); }
    }

    // Update is called once per frame
    void Update()
    {
        is_attack = Physics.CheckBox(transform.position, size, Quaternion.identity, player_layer);
    }

    IEnumerator Attack(float time)
    {
        {
            Player_Health.NowHP -= _damage;
            is_attack = false;
        }
        yield return 0;
    }
}
