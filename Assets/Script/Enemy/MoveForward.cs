using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    private ParticleSystem ps;
    public float speed = 30.0f;

    [Range(0,1)]
    //public float DelayTime = 0.2f;
    private bool is_go = false;

    void Start()
    {
        ps = this.GetComponent<ParticleSystem>();//取得粒子
        StartCoroutine(go());
    }

    void Update()
    {
        if (is_go)
        { transform.Translate(0, 0, Time.deltaTime * speed); }
    }
    /* 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject exp = Instantiate(Exp_Ps, other.transform);
            Destroy(this.gameObject);
            //Debug.Log("hit");
        }    
    }*/
    IEnumerator go()
    {
        yield return new WaitForSeconds(ps.startDelay);
        is_go = true;
    }
}
