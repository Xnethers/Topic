using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class summonsmoke : MonoBehaviour
{
    [SerializeField, Range(1, 3)]
    public float delay;
    public GameObject enemy;
    private ParticleSystem ps;
    GameObject c;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Delay());
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.IsAlive() == false)//判斷粒子是否存活
        { c.GetComponent<NavMeshAgent>().enabled = true; Destroy(this.gameObject); }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        c = Instantiate(enemy, transform.position, transform.rotation);
    }
}
