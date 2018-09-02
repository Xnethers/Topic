using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Player_healthBar : MonoBehaviour
{
    public Image HP_Bar;
    public Image MP_Bar;
    private Player_Health HPMP;
    

    // Use this for initialization
    void Start()
    {
		HPMP = GameObject.FindWithTag("Player").GetComponent<Player_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        HP_Bar.fillAmount = HPMP.NowHP / HPMP.MaxHP;
        MP_Bar.fillAmount = HPMP.NowMP / HPMP.MaxMP;
    }
}
