using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCase : MonoBehaviour
{

    Vector3 currentDestination;

    //public List<int> transSTATE = new List<int>();
    public List<Transform> Patrolpoint = new List<Transform>();
    List<Vector3> Patrolpoint_p = new List<Vector3>();

	float step = 0.01f;

    public float waitTime = 3f;
    bool canMoving = true;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < Patrolpoint.Count; i++)
        {
            Patrolpoint_p.Add(new Vector3(Patrolpoint[i].position.x, transform.position.y, Patrolpoint[i].position.z));
            //Patrolpoint_p[i] = new Vector3(Patrolpoint[0].position.x, transform.position.y, Patrolpoint[0].position.z);
        }
        Debug.Log(Patrolpoint_p.Count);
        if (Patrolpoint[0] != null)
        { currentDestination = Patrolpoint_p[0]; }
    }

    // Update is called once per frame
    void Update()
    {
        random_moving();
    }

    void random_moving()
    {
        if (canMoving)
        {
            transform.position = Vector3.Lerp(transform.position, currentDestination, step);
            float d = Vector3.Distance(transform.position, currentDestination);
            if (d < 0.5f)  //到达目的地后暂停3s，然后切换目的地，达到来回走动的效果
            {
                canMoving = false;
                StartCoroutine(delayCoroutine(waitTime));     //停留3s再返回
            }

        }
    }

    IEnumerator delayCoroutine(float waittime)//停滯時間
    {
        if (Vector3.Equals(currentDestination, Patrolpoint_p[0]))
        {
            currentDestination = Patrolpoint_p[1];
        }
        else
        {
            currentDestination = Patrolpoint_p[0];
        }

        yield return new WaitForSeconds(waittime);
        canMoving = true;
    }

}
