using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{

    
    public int MaxHP;
	public static float NowHP;
	public int MaxMP;

	[SerializeField]
	public static float NowMP;
	public float SecMP;
    public bool isDead = false;
	public bool isInvincibility = false;
	public bool isUnlimitedMP = false;
	public GameObject UIPrefab_ShowDamage;

    // Use this for initialization
    void Start()
    {
		NowHP = MaxHP;
		NowMP = MaxMP;
    }

    // Update is called once per frame
    void Update()
    {


        if (isInvincibility)
		{
			NowHP = MaxHP;
		}
		if (isUnlimitedMP)
		{
			NowMP = MaxMP;
		}

		if (!isDead)
		{
			/*HP*/
			if (NowHP <= 0)
			{
				NowHP = 0;
				isDead = true;
			}
			/*MP*/
			if (NowMP < MaxMP)
			{
				//if (ComboSystem && ComboSystem.CanCombo)
                	NowMP += Time.deltaTime * SecMP;
			}
			else
			{
				NowMP = (float)MaxMP;
			}
		}
		else
		{
			NowHP = 0;
			NowMP = 0;
		}
	}

	public static void SetHP(int damage)
	{
		NowHP -= damage;
	}
	public void SetMP(float mana)
	{
		NowMP += mana;
	}
	public float GetHPPercent()
	{
		return ((float)NowHP/(float)MaxHP) * 100;
	}
    
}
