using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Lock : MonoBehaviour
{
    public Camera maincamera;
    //public Transform Target;//玩家的目標
    public RectTransform rectTransform;
    public Image targetUI;//瞄準UI
    //public Image targetUI_Lock;//瞄準UI(鎖定後)
    public Color targetColor;//UI顏色

    private Vector2 screenpos = Vector3.zero;

    void Start()
    {
        targetUI = GetComponent<Image>();
    }
    void Update()
    {

        //當玩家有目標時
        if (Player_target._target != null)
        { LockTarget(Player_target._target); }
        else
        { Unlock(); }
        //沒鎖定時

        if (transform.position.x > Screen.width)
        { Unlock(); }
        else if (transform.position.y > Screen.height)
        { Unlock(); }
    }

    public void LockTarget(Transform target)
    {
        Transform Target;//玩家的目標
        Target = target;
        targetUI.color = targetColor;
        screenpos = maincamera.WorldToScreenPoint(Target.position);
        transform.position = screenpos;
    }

    void Unlock()
    { targetUI.color = Color.clear; }
}
