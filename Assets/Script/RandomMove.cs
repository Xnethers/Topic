using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    public Vector3 TranslateValue;//位移值
    public float Speed = 1.0f;
    public float RandMin;
    public float RandMax;

    private float timemax;

    private float timer;//計時器
    private int is_state = 1;

    float deg;

    //往一個方向旋轉
    //移動,計時器計時
    //時間到X秒後
    //換一個方向旋轉
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {


        if (is_state == 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            timer = timer + Time.deltaTime;
            if (timer > timemax)
            { is_state = 1; }
            //else if ()
        }
        else if (is_state == 1)
        {
            Rotation_To(TranslateValue + transform.position);
            if (Rotation_To(TranslateValue + transform.position) == true)
            { is_state = 2; }
            
        }
        else if (is_state == 2)
        {
            Reset();
            if (timer == 0)
            { is_state = 0; }
        }

    }
    void Reset()
    {
        TranslateValue = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        timemax = Random.Range(RandMin, RandMax);
        timer = 0.0f;
    }

    Vector3 targetposition;
    /*
    public void Move_WithOutRandom(Vector3 TargetPosition, float input_minrange)
    {
        minrange = input_minrange;
        targetposition = TargetPosition;
        TranslateValue = (TargetPosition - transform.position).normalized;
        TranslateValue = new Vector3(TranslateValue.x, 0, TranslateValue.z);

        is_timeron = false;
        timer = 0.0f;
    }
    */

    public void Avoid(Vector3 TargetPosition, float input_minrange)
    {
        targetposition = (TargetPosition - transform.position).normalized; ;
        TranslateValue = new Vector3(-targetposition.x, 0, -targetposition.z);
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Time.deltaTime * -Speed);
        //is_timeron = false;
        timer = 0.0f;
    }

    public bool Rotation_To(Vector3 t)
    {
        Vector3 targetDir = t - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 0.1f, 0.0F);

        transform.rotation = Quaternion.LookRotation(newDir);

        Vector3 front_direction = transform.forward;

        //判定是否已經轉完方向
        float rad = Vector3.Dot(front_direction.normalized, TranslateValue.normalized);
        float d = Mathf.Clamp(rad, -1.0f, 1.0f); // 追加
        deg = Mathf.Acos(d) * Mathf.Rad2Deg;

        if (deg <= 5)
            return true;
        else
            return false;
    }
}