using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class summon : SkillBasicData
{
    public GameObject creation;
    public List<GameObject> creatlist = new List<GameObject>();

    [SerializeField, Range(1, 10)]
    public float distance;
    float mindistance = 1;
    private Vector3 range;
    private Vector3 next_position;

    // Update is called once per frame
    void Update()
    {
        //debug
        if (Input.GetKeyDown(KeyCode.V))
        { UseSkill(); }
        if (CanUseSkill && isUse && isAnimation)
        {
            StartCD();
            Creat();
            _animator.SetBool("summon", true); ;
            isUse = false;
        }

        //進入CD
        CDing();

    }

    void Start()
    {
        for (int i = 0; i < creatlist.Count; i++)
        { creatlist[i] = creation; }
    }

    void Creat()
    {
        
        for (int j = 0; j < creatlist.Count; j++)
        {
            if(j == 0)
            {_animator.Play("summon");}
            newposition(j);
            GameObject c = Instantiate(creatlist[j], next_position, transform.rotation);
        }


    }

    void newposition(int J)
    {
        if (J % 4 == 0)
            range = new Vector3(Random.Range(mindistance, distance), 0, Random.Range(mindistance, distance));
        else if (J % 4 == 1)
            range = new Vector3(-Random.Range(mindistance, distance), 0, Random.Range(mindistance, distance));
        else if (J % 4 == 2)
            range = new Vector3(-Random.Range(mindistance, distance), 0, -Random.Range(mindistance, distance));
        else if (J % 4 == 3)
            range = new Vector3(Random.Range(mindistance, distance), 0, -Random.Range(mindistance, distance));
        next_position = transform.position + range;
    }
}
