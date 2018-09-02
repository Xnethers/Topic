using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy_Health : MonoBehaviour
{

    // Use this for initialization
    public float _health = 1000;
    public int max_health = 1000;
    public float Die_time = 3;
    public ParticleSystem Die_particle;
    private AI _ai;
    private Fall_item _fall;

    // Use this for initialization
    void Start()
    {
        _ai = GetComponent<AI>();
        _fall =GetComponent<Fall_item>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_health < 0)
        {
            ParticleSystem _dieparticle = (ParticleSystem)Instantiate(Die_particle, transform.position, Die_particle.transform.rotation);
            _dieparticle.transform.SetParent(transform);
            _dieparticle.Play();
            _ai._animator.Play("M_die");
            _health = 0;
        }
        if (_health == 0)
        {
            Destroy(gameObject, Die_time);
            Destroy(_fall,Die_time);
        }
    }
}
