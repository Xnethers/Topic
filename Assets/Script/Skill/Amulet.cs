using UnityEngine;
using System.Collections;
/*附加腳本時自動生成AudioSource元件*/
[RequireComponent(typeof(AudioSource))]
public class Amulet : SkillBasicData
{

    /*變數宣告*/
    //斧頭的來源 : 帶有Rigidbody元件的物件
    //投射的 z 軸及 y 軸速度值 : 整數值
    //投射聲 : 聲音檔
    public Rigidbody AmuletSource;
    private Transform _target;
    public AudioClip ThrowerSound;
    public float Speed = 5;
    //public int ThrowerPowerZ = 10;



    // Use this for initialization
    void Start()
    {
    }

    /* 功能 : 持續執行 (投射) */
    //如果發射狀態為(是) --> 當我們按下開火鍵(Fire1)時 -->於腳本附加的物件上動態產生一把斧頭 -->
    //給予方向及力量將其投射出去 --> 避開斧頭與自身的物理碰撞現象 --> 播放投射聲音。
    void Update()
    {
        //進入CD
        CDing();

        if (level == 1)
        {
            if (CanUseSkill && Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartCD();

                shotAmulet(1);
            }
        }

        else if (level == 2)
        {
            if (CanUseSkill && Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartCD();
                shotAmulet(3);
            }
        }
    }

    void shotAmulet(int i)
    {
        _animator.Play("Amulet");
        for (int a = 1; a < i; a++)
        {
            Rigidbody Amulet = (Rigidbody)Instantiate(AmuletSource, transform.position, transform.rotation);
            Amulet.velocity = transform.TransformDirection(Vector3.forward * Speed);
            Physics.IgnoreCollision(Amulet.GetComponent<Collider>(), transform.parent.parent.GetComponent<Collider>());
        }

        
        GetComponent<AudioSource>().PlayOneShot(ThrowerSound);
    }
}