using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summon : SkillBasicData
{

    public GameObject _summoner1;
    //public GameObject _summoner2;

    [SerializeField,Range(1,10)]
    private float maxrange;
	[SerializeField,Range(1,10)]
    private float minrange;
	


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //debug
        if (Input.GetKeyDown(KeyCode.V))
        { UseSkill(); }

        if (CanUseSkill && isUse)
        {
            GameObject _summoner = Instantiate(_summoner1, transform.position + new Vector3(Random.onUnitSphere.x * Random.Range(minrange,maxrange), 0, Random.onUnitSphere.z * Random.Range(minrange,maxrange)), transform.rotation);
            { StartCD(); isUse = false; }
        }
        //進入CD
        CDing();

    }

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
}
