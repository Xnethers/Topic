using UnityEngine;
using System.Collections;
/*附加腳本時自動生成AudioSource元件*/
[RequireComponent(typeof(AudioSource))]
public class _08_Thrower : MonoBehaviour {

	/*變數宣告*/
	//斧頭的來源 : 帶有Rigidbody元件的物件
	//投射的 z 軸及 y 軸速度值 : 整數值
	//投射聲 : 聲音檔
	public Rigidbody AxeSource;
	public int ThrowerPowerY = 5;
	public int ThrowerPowerZ = 10;
	public AudioClip ThrowerSound;

	// Use this for initialization
	void Start () {
	
	}
	
	/* 功能 : 持續執行 (投射) */
	//如果發射狀態為(是) --> 當我們按下開火鍵(Fire1)時 -->於腳本附加的物件上動態產生一把斧頭 -->
	//給予方向及力量將其投射出去 --> 避開斧頭與自身的物理碰撞現象 --> 播放投射聲音。
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Rigidbody Axe = (Rigidbody)Instantiate(AxeSource, transform.position, transform.rotation);
			Axe.velocity = transform.TransformDirection(new Vector3(0, ThrowerPowerY, ThrowerPowerZ));
			Physics.IgnoreCollision(Axe.GetComponent<Collider>(), transform.GetComponent<Collider>());
			GetComponent<AudioSource>().PlayOneShot(ThrowerSound);
		}
	}
}
