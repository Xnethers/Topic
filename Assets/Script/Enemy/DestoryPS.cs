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
    int minscale = 1;
    int maxscale = 5;
    int lifttime = 4;

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
        _collision.size = Vector3.Lerp(_collision.size, new Vector3(maxscale, maxscale, _collision.size.z), Time.deltaTime);
        Debug.Log(Scale);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.gameObject.tag == "Player")
        { other.gameObject.GetComponent<Player_Health>().NowHP -= Damage; }
        Destroy(this.gameObject);
    }
}
