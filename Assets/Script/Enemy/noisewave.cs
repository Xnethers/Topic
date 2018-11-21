using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noisewave : SkillBasicData
{
    [SerializeField] private noisewaveShoter[] Point;//宣告複製原點
    [SerializeField] float delaytime;

     private Transform player;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
            foreach (noisewaveShoter item in Point)
            { item.gameObject.transform.rotation *= Quaternion.Euler(40, 0, 0); }
        
        
            foreach (noisewaveShoter item in Point)
            { item.gameObject.transform.rotation *= Quaternion.Euler(0, 0, 0); }
        
        //Debug
        if (Input.GetKeyDown(KeyCode.M))
        { UseSkill(); }

        if (CanUseSkill && isUse)
        {
            _animator.Play("noisewave");
            StartCoroutine("delay");
        }
        //進入CD
        CDing();
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(delaytime);
        StartCoroutine("creatparticle");
        StopCoroutine("delay");
    }


    IEnumerator creatparticle()
    {
        
        foreach (noisewaveShoter i in Point)
        {
            i.k = (transform.position.x - player.position.x) / Vector3.Distance(transform.position, player.position);
            i.shot = true;
            StartCD();
            isUse = false;
        }
        yield return null;
    }
}
