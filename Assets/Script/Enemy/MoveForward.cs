using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    public float speed = 30.0f;
    public GameObject Exp_Ps;
    
	void Update () {
        transform.Translate(0, 0, Time.deltaTime * speed);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject exp = Instantiate(Exp_Ps, other.transform);
            Destroy(this.gameObject);
            //Debug.Log("hit");
        }    
    }
}
