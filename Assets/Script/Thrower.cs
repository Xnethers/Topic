using UnityEngine;
using System.Collections;
/*附加腳本時自動生成AudioSource元件*/
[RequireComponent(typeof(AudioSource))]
public class Thrower : MonoBehaviour
{

    /*變數宣告*/
    //投射的 z 軸及 y 軸速度值 : 整數值
    //投射聲 : 聲音檔
    public Rigidbody bucketSource;

    public Transform _player;
    public AudioClip ThrowerSound;
    public int ThrowerPowerY = 5;
    //public int ThrowerPowerZ = 10;


    public float _timer;

    private float i;

    public float ThrowerPower;

    float j = 1.2f;



    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    /* 功能 : 持續執行 (投射) */
    //如果發射狀態為(是) --> 當我們按下開火鍵(Fire1)時 -->於腳本附加的物件上動態產生一把斧頭 -->
    //給予方向及力量將其投射出去 --> 避開斧頭與自身的物理碰撞現象 --> 播放投射聲音。
    void Update()
    {
        Timer();
        ThrowerPower = Vector3.Distance(_player.position, transform.position);

        if (i == 0)
        {
            Rigidbody bucket = (Rigidbody)Instantiate(bucketSource, transform.position, transform.rotation);
            bucket.transform.SetParent(transform);
            bucket.velocity = transform.TransformDirection(new Vector3(0, ThrowerPowerY, ThrowerPower * j));
            Physics.IgnoreCollision(bucket.GetComponent<Collider>(), transform.GetComponent<Collider>());
            GetComponent<AudioSource>().PlayOneShot(ThrowerSound);
        }
    }

    void Timer()
    {
        i += Time.deltaTime;
        if (i >= _timer)
        {
            i = 0;
        }
    }

    public void reset()
    {
        i = 0;
    }
}
