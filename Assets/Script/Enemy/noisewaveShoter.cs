using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noisewaveShoter : MonoBehaviour
{
    public GameObject _noisewave;//宣告投射物
    private Vector3 Point;//宣告複製原點
    //public float Passtime = 0;//宣告經過時間
    [SerializeField] private float interval = 0.25f;//宣告子彈間隔時間

    [SerializeField] public bool shot = false;
    public int count = 0; //子彈數
    int i = 0;


    // Use this for initialization
    void Start()
    {
        Point = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (shot && i < count)
        {
            GameObject bullet = Instantiate(_noisewave, Point, transform.rotation);
            i++;
            if (i == count)
            { i = 0; shot = false;}
			else
            {StartCoroutine(timer());}
        }

    }

    IEnumerator timer()
    {
        shot = false;
        yield return new WaitForSeconds(interval);
        shot = true;
    }
}
