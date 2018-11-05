using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noisewave : SkillBasicData
{
    public GameObject _noisewave;//宣告投射物
    [SerializeField] private noisewaveShoter[] Point;//宣告複製原點
    [SerializeField] float delaytime;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            i.shot = true;
            StartCD();
            isUse = false;
        }
        yield return null;
    }

    public void use()
    {
        UseSkill();
    }
}
