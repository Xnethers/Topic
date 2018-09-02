using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFlag : MonoBehaviour
{
	public bool Pabody;
	public bool Hurt;
	public bool Fly;
	public bool Invincibility;
	public bool Avoid;
	public bool DEFStance;
	public bool AvoidSword;
	public bool ThreeSword;
	public bool FootKick;
	public bool NormalAttack;
	public bool AssaulSword;
	public bool SharpSpines;
	public bool Retreat;
	public bool EarthSword;

	private float InvincibilityTime;

	public void CallAllSkillStop()
	{
		gameObject.BroadcastMessage("StopSkill" , SendMessageOptions.DontRequireReceiver);
	}

	public void SetInvincibility(float time)
	{
		InvincibilityTime = time;
		StopCoroutine("StartInvincibility");
		StartCoroutine("StartInvincibility");
	}
	IEnumerator StartInvincibility()
	{
		Invincibility = true;
		yield return (new WaitForSeconds(InvincibilityTime));
		Invincibility = false;
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) 
	{
		if (stream.isWriting)
		{
			stream.Serialize(ref Invincibility);
		}
		else
		{
			stream.Serialize(ref Invincibility);
		}
	}
}
