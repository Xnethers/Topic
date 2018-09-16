using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorlocker : MonoBehaviour
{
    public List<dooropen> locker = new List<dooropen>();
    Inventory _inventory;
    public Item _key;

    // Use this for initialization
    void Start()
    {
        for (int j = 0; j < locker.Count; j++)
        { }
        _inventory = FindObjectOfType<Inventory>();
        Debug.Log(_inventory);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_inventory)
            {
                for (int i = 0; i < _inventory.items.Count; i++)
                {
                    if (_inventory.items[i] == _key)
                    {}
                }

            }
        }
    }
}
