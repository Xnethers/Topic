using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public GameObject Projectile;//宣告投射物
    public Transform Point;//宣告複製原點
    private float Passtime = 0;//宣告經過時間
    public float interval = 0.25f;//宣告子彈間隔時間

    void Update()
    {
        Passtime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && Passtime > interval)
        {
            Instantiate(Projectile, Point);
            Passtime = 0;
        }
    }
}
