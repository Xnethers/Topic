using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI3 : MonoBehaviour
{
    public enum AIState
    {
        RandomMoving,
        Track,
        Attack
    }

    public AIState Status;
    NavMeshAgent nav;
    Vector3 currentDestination;

    public List<int> transSTATE = new List<int>();
    public Transform p1;

    Vector3 _p1;
    public Transform p2;

    Vector3 _p2;
    public float waitTime = 3f;
    bool canMoving = true;
    GameObject _player;

    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        _p1 = p1.position;
        _p2 = p2.position;
        currentDestination = _p2;
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (Status)
        {
            case AIState.RandomMoving:
                {
                    random_moving();
                    break;
                }
            case AIState.Track:
                {
                    track();
                    break;
                }
            case AIState.Attack:
                {
                }
                break;
        }
    }

    void random_moving()
    {
        if (canMoving)
        {
            nav.SetDestination(currentDestination);

            if (nav.remainingDistance < 0.5f)  //到达目的地后暂停3s，然后切换目的地，达到来回走动的效果
            {
                canMoving = false;
                StartCoroutine(delayCoroutine(waitTime));     //停留3s再返回
            }
        }
    }
    

    void track()
    {
        if (!canMoving)
        {
            if (nav.remainingDistance < 0.5f)
            { }
            else
            {
                nav.SetDestination(_player.transform.position);
            }
        }
    }

    public void SmoothRotation(float a)//旋轉角度
    {
        float y = 3.0f;
        float rotateSpeed = 0.1f;
        transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, a, ref y, rotateSpeed), 0);
    }

    public void DistanceOfTransform(float t)//移動
    {
        Vector3 target_P = transform.position + Vector3.forward * t;
        transform.position = Vector3.MoveTowards(transform.position,target_P,Time.deltaTime);
    }

    IEnumerator delayCoroutine(float waittime)//停滯時間
    {

        if (Vector3.Equals(currentDestination, _p1))
        {
            currentDestination = _p2;
        }
        else
        {
            currentDestination = _p1;
        }
        yield return new WaitForSeconds(waittime);
        canMoving = true;
    }

}
