using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilityvalue : MonoBehaviour 
{
	[Header("技能等級")]
	[SerializeField, Range(1f, 2f)]
	public int NormalAttack;//普通揮砍
	[SerializeField, Range(1f, 2f)]
	public int Amulet;//馭符術
	[SerializeField, Range(1f, 2f)]
	public int Fairy_guide;//仙人指路
	[SerializeField, Range(1f, 2f)]
	public int MagicField;//雷帝招來
	[SerializeField, Range(1f, 2f)]
	public int ExSkill; //無極劍陣

	[Header("暴擊率")]
	public float mCrit;//角色爆擊率 0 - 100%
	public float mCritDamage = 150;//角色爆擊傷害 X%
	public Object LevelUpParticle;

	public static int Balance = 0;

	void Start()
	{
		LevelUpParticle = Resources.Load("Particle/Normal/升級特效");
	}
	public void LevelUp()
	{
		
		GameObject particle = (GameObject)Instantiate(LevelUpParticle , transform.position+new Vector3(0,1.3f,0), transform.rotation);
		particle.transform.parent = transform;
	}
}
