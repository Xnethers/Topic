using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//圓環狀控制技
public class Stun : MonoBehaviour {
	
	private ParticleSystem ps;
    [SerializeField]private BoxCollider _collision;

	public float _duration;

    [Header("Change Trigger Scale")]
    public bool If_change = true;
    public Vector3 maxscale = new Vector3(3, 0.3f, 3);
    void Start()
    {
        ps = this.GetComponentInChildren<ParticleSystem>();//取得粒子
	}	


	// Update is called once per frame
	void Update () {
		if (ps.IsAlive() == false)//判斷粒子是否存活
        {
            Destroy(this.gameObject);
        }
	}

	void FixedUpdate()
    {
        if (If_change)//10,10,5
            gameObject.transform.localScale = Vector3.Lerp(this.transform.localScale, maxscale, Time.deltaTime);
    }

	 void OnTriggerEnter(Collider other)
	 {
		 if (other.gameObject.tag == "Player")
		 {
			other.GetComponent<Player_State>().Stun(_duration);
		 }
	 }
}
