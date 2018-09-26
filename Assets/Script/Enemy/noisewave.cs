using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noisewave : SkillBasicData
{
    ParticleSystem _wave;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //進入CD
        CDing();

		
    }

    void Noisewave()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player_Health>().NowHP -= Damage;
        }
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
