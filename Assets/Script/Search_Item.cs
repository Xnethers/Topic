using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Search_Item : MonoBehaviour
{
    public Image UI;

    [Header("探索物品")]

    GameObject _object;
    public ItemPickup _itemup;
    public bool is_search;

    [Header("物品訊息")]
    public Flowchart _flowchart;

    //RaycastHit hit;
    private Collider[] hit = new Collider[1];

    public float distance;



    // Update is called once per frame
    void Update()
    {
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, 1 << LayerMask.NameToLayer("Item")))
        Physics.OverlapSphereNonAlloc(transform.position, distance, hit, 1 << LayerMask.NameToLayer("Item"));

        if (CanSearchItem())
        {
            UI.enabled = true;
            GetItemMessage();
            if (Input.GetKeyDown(KeyCode.F))
            { is_search = true; }
        }
        else
        {
            hit[0] = null;
            UI.enabled = false;
            is_search = false;
        }
    }

    public bool CanSearchItem()
    {
        if (hit[0] != null && Vector3.Distance(hit[0].transform.position, transform.position) <= distance)
        {
            if (hit[0].tag == "Item")
            {
                _object = hit[0].gameObject;
                _itemup = _object.GetComponent<ItemPickup>();
                return true;
            }
            else
            { return false; }
        }
        else
        { return false; }
    }


    void GetItemMessage()
    {
        if (is_search)
        {
            Player_State.ismove = false;

            if (_itemup.item.ID == 0000)
            { _flowchart.ExecuteBlock("nothing"); }
            else if (_itemup.item.ID == 1)
            {
                _flowchart.ExecuteBlock("Get_Lingshi");
                _itemup.PickUp();
                is_search = false;
            }
            else if (_itemup.item.ID > 0020)
            {
                _flowchart.SetStringVariable("classroom", _itemup.item.name);
                _flowchart.ExecuteBlock("Get_Key");
                _itemup.PickUp();

            }

            is_search = false;
        }
    }

}