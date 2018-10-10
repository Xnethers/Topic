using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Normal Attack Damage
public class NA_D : MonoBehaviour
{

    float _damage;
    private ParticleSystem ps;

    // Use this for initialization
    void Start()
    {
        ps = this.GetComponent<ParticleSystem>();//取得粒子
		_damage = Transform.FindObjectOfType<NormalAttack>().CalculateDamege();
    }

    // Update is called once per frame
    void Update()
    {

        if (ps.IsAlive() == false)//判斷粒子是否存活
        { Destroy(this.gameObject); }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponentInParent<Enemy_Health>()._health -= _damage;
            other.GetComponentInParent<AI>().isHurt = true;
			Debug.Log("hit");
            Destroy(gameObject);
        }
    }
}
