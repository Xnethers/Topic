using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//投擲物
public class damage : MonoBehaviour
{
    public enum ObjectType
    {
        bucket,
        amulet

    }
    public ObjectType _type;
    public float _damage;
    public float DestroyTime = 3;

    // Use this for initialization
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        switch (_type)
        {
            case ObjectType.bucket:
                { _damage = GetComponentInParent<Enemy_Attack>().Damage; }
                break;
            case ObjectType.amulet:
                { _damage = Transform.FindObjectOfType<Amulet>().CalculateDamege(); }
                break;
        }
        Destroy(gameObject, DestroyTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (_type == ObjectType.bucket && other.tag == "Player")
        {
            other.GetComponentInParent<Player_Health>().NowHP -= _damage;
            Destroy(gameObject);
        }
        else if (_type == ObjectType.amulet && other.tag == "Enemy")
        {
            other.GetComponentInParent<AI>().Hurt(_damage);
            Destroy(gameObject);
        }
    }

}
