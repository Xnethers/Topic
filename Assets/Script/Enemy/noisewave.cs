using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noisewave : SkillBasicData
{
    public GameObject _noisewave;//宣告投射物
    public Transform Point;//宣告複製原點
    public float Passtime = 0;//宣告經過時間
    public float interval = 0.25f;//宣告子彈間隔時間

    // Use this for initialization
    void Start()
    {
        Point = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Passtime += Time.deltaTime;
        //Debug
        if (Input.GetKeyDown(KeyCode.M))
            UseSkill();

        if (CanUseSkill && isUse)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Passtime > interval)
                {
                    GameObject bullet = Instantiate(_noisewave, Point);
                    Passtime = 0;
                }
                if (i == 4)
                { StartCD(); isUse = false; }
            }
        }
        //進入CD
        CDing();

    }

    void Noisewave()
    {
        UseSkill();
    }

    public bool Rotation_To(Vector3 t)
    {

        Vector3 targetDir = t - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 0.1f, 0.0F);

        transform.rotation = Quaternion.LookRotation(newDir);

        Vector3 front_direction = transform.forward;

        //判定是否已經轉完方向
        float rad = Vector3.Dot(front_direction.normalized, t.normalized);
        float d = Mathf.Clamp(rad, -1.0f, 1.0f); // 追加
        //float deg = Mathf.Acos(d) * Mathf.Rad2Deg;

        if (d > 0)
            return true;
        else
            return false;
    }
}
