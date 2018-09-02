using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Track : MonoBehaviour
{
    private NavMeshAgent _Enemy;
    public Transform p;


    // Use this for initialization
    void Start()
    {
        _Enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Track_player(Transform _player)
    {
        _Enemy.SetDestination(_player.position);
         p = _player;
    }

    public void stop()
    {
        _Enemy.isStopped = true;
    }

    public void work()
    {
        _Enemy.isStopped = false;
    }
}
