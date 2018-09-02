using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creat_Enemy : MonoBehaviour
{

    public GameObject Long_Enemy;
    public GameObject Near_Enemy;
    private float max = 5;
    private float min = -5;
    GameObject[] Enemy_number;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Timer", 30f, 3f);
		Enemy_number = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Timer()
    {
        float X = Random.Range(min, max);
        float Z = Random.Range(min, max);
        Instantiate(Long_Enemy, transform.position + new Vector3(X, 0, Z), transform.rotation);
        Enemy_number = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy_number.Length > 15)
        { CancelInvoke(); }
        else
        {        }
    }
}
