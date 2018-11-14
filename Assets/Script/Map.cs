using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] float proportion;//比例
    void Start()
    {
        s_Player = GameObject.FindWithTag("Player").transform;
        s_Benchmark = GameObject.FindWithTag("Benchmark").transform;
        //m_Player = Transform.FindWithTag("m_Player").transform;
    }
    [SerializeField] float MaxRadius = 25;
    [SerializeField] Transform s_Player;//實際玩家位置
    [SerializeField] Transform s_Benchmark;//實際基準點

    [SerializeField] RectTransform m_Player;//地圖玩家位置
    [SerializeField] RectTransform m_Benchmark;//地圖基準點


    [SerializeField] private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        Set_Direction();
        direction = Vector3.ClampMagnitude(direction, MaxRadius);
        m_Player.localPosition = m_Benchmark.localPosition + direction * proportion;
    }
    void Set_Direction()
    {
        //Debug.Log(Destination.position + ":" + WorldPosition.position);
        direction = s_Benchmark.position - s_Player.position;
        direction = new Vector3(direction.x, direction.z, 0);
    }
}