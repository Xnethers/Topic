using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shock_wave : SkillBasicData
{

    public GameObject _noisewave;//宣告投射物
    //private Vector3 Point;//宣告複製原點
    //public float Passtime = 0;//宣告經過時間
    public float interval = 0.25f;//宣告子彈間隔時間

    [SerializeField]bool shot;
    public int count = 0; //子彈數
    int i = 0;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug
        if (Input.GetKeyDown(KeyCode.B))
        { UseSkill(); shot = true; }
        //

        if (CanUseSkill && isUse)
        {
            _animator.Play("shock_wave");
            if (shot && i < count)
            {
                GameObject bullet = Instantiate(_noisewave, transform.position, _noisewave.transform.rotation);
                i++;
                StartCoroutine(timer());
            }
            if (i == count)
            { StartCD(); isUse = false; i = 0; }
        }
        //進入CD
        CDing();

    }

    IEnumerator timer()
    {
        shot = false;
        yield return new WaitForSeconds(interval);
        shot = true;
    }
}
