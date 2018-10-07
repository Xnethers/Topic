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
        _inventory = FindObjectOfType<Inventory>();
        Debug.Log(_inventory);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _inventory)
        {
            foreach (Item i in _inventory.items)
            {
                if (i == _key)
                {
                    foreach (dooropen k in locker)
                    {
                        k.enabled = true;
                        _inventory.RemoveItem(i);
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}
