using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_item : MonoBehaviour
{

    public GameObject item;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {}

    void OnDestroy()
    {
        Instantiate(item, transform.position, transform.rotation);
    }
}
