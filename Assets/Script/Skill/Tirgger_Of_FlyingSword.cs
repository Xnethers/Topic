using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//仙人指路技能碰撞
public class Tirgger_Of_FlyingSword : MonoBehaviour
{

    public float speed = 30.0f;
    public float Damage = 10;

    public float Skill_time = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * speed);
        StartCoroutine(Timer(Skill_time));
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy_Health>()._health -= Damage;
            other.GetComponentInParent<AI>().isHurt = true;//打擊感
        }
    }

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
