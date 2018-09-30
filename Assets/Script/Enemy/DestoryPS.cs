using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//推進物
public class DestoryPS : MonoBehaviour
{

    private ParticleSystem ps;
    private BoxCollider _collision;
    public float speed = 30.0f;
    public float Damage = 0;
    float Scale = 0;

    void Start()
    {
        ps = this.GetComponent<ParticleSystem>();//取得粒子
        _collision = this.GetComponent<BoxCollider>();
    }

    void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * speed);
        if (ps.IsAlive() == false)//判斷粒子是否存活
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        Scale += Time.deltaTime / speed;
        _collision.size = new Vector3(_collision.size.x + Scale, _collision.size.y + Scale, _collision.size.z);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.gameObject.tag == "Player")
        { other.gameObject.GetComponent<Player_Health>().NowHP -= Damage; }
        Destroy(this.gameObject);
    }
}
