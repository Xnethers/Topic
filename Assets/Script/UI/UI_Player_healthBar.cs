using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Player_healthBar : MonoBehaviour
{
    public Image HP_Bar;
    public Image MP_Bar;

    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        HP_Bar.fillAmount = Player_Health.NowHP / 100;
        MP_Bar.fillAmount = Player_Health.NowMP / 100;

    }
}
