using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniper : SkillBasicData
{

    public GameObject _noisewave;//宣告投射物
    public Transform Point;//宣告複製原點
    //public float Passtime = 0;//宣告經過時間
    public float interval = 0.25f;//宣告子彈間隔時間

    bool shot;
    public int count = 0; //子彈數
    int i = 0;


    // Use this for initialization
    void Start()
    {
        Point = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug
        if (Input.GetKeyDown(KeyCode.N)){ UseSkill(); shot = true; }
		//

        if (CanUseSkill && isUse)
        {
           if (shot && i < count)
            {
                GameObject bullet = Instantiate(_noisewave, Point);
                i++;
                StartCoroutine(timer());
            }
            if (i == count)
            { StartCD(); isUse = false; i = 0; }
        }
        //進入CD
        CDing();

    }

    public void use()
    {
        UseSkill();
    }

    IEnumerator timer()
    {
        shot = false;
        yield return new WaitForSeconds(interval);
        shot = true;
    }
}
