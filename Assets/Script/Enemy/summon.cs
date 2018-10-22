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
        { UseSkill(); Creat();}
        if (CanUseSkill && isUse && isAnimation)
        {  StartCD(); }

        //進入CD
        CDing();

    }

    /*
    public Vector3 get_position()
    {
        float X = transform.position.x + Random.Range(-10.0F, 10.0F);
        //以目前物件的x座標為基準，亂數生成正負10的範圍做為新生成物件的x座標
        float Z = transform.position.z + Random.Range(-10.0F, 10.0F);
        //以目前物件的z座標為基準，亂數生成正負10的範圍做為新生成物件的z座標
        Vector3 A = new Vector3(X, Terrain.activeTerrain.SampleHeight(new Vector3(X, transform.position.y, Z)) + 0.5F, Z);
        //new Vector3的y座標為取得之地表高度再加0.5F，防止新物件掉落地表下
        Vector3 _destination = new Vector3(0, 0, 0);
        return _destination;
    }
    */

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < creatlist.Count; i++)
        { creatlist[i] = creation; }
    }

    void Creat()
    {
        for (int j = 0; j < creatlist.Count; j++)
        {
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
