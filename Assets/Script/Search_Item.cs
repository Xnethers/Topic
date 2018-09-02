using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Search_Item : MonoBehaviour
{
    public Image UI;
    public float _angle = 120;

    [Header("探索物品")]
    public Item _item;
    public bool is_search;
    [Header("物品訊息")]
    public Flowchart _flowchart;

    //RaycastHit hit;
    private Collider[] hit = new Collider[1];

    public float distance;

    private Bag _bag;


    // Use this for initialization
    void Start()
    {
        _bag = GetComponent<Bag>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, 1 << LayerMask.NameToLayer("Item")))
        Physics.OverlapSphereNonAlloc(transform.position, distance, hit, 1 << LayerMask.NameToLayer("Item"));

        if (hit[0] != null && Input.GetKeyDown(KeyCode.F))
        { is_search = true; }
        //Debug.Log(hit[0]);
        get_item();
        CanSearchItem();
    }

    void CanSearchItem()
    {
        if (hit[0] != null)
        {
            if (hit[0].tag == "Item")
            {
                _item = hit[0].GetComponent<Item>();
                UI.enabled = true;
            }
            else if (hit[0].tag == "NPC")
            { UI.enabled = true; }
            if (Vector3.Distance(hit[0].transform.position, transform.position) > distance)
            { hit[0] = null; }
        }

        else
        {
            _item = null;
            UI.enabled = false;
        }

    }

    void get_item()
    {
        if (is_search && _item)
        {
            Player_State.ismove = false;
            if (_item)
            {
                if (_item._name == "Lingshi")
                {
                    Bag.Lingshi++;
                    _flowchart.ExecuteBlock("Get_Lingshi");
                    Destroy(_item.gameObject);
                }
                else if (_item._name == "Null")
                { _flowchart.ExecuteBlock("nothing"); }
                else if (_item._name == "Key")
                {
                    _flowchart.SetStringVariable("classroom", _item._description);
                    _flowchart.ExecuteBlock("Get_Key");
                    _bag.Get_key(_item._key);
                    Destroy(_item.gameObject);
                }
            }
            else
            { }
            is_search = false;
        }
    }
    /* 
        bool detection(Vector3 target)
        {
            Vector3 front_direction = transform.forward;
            Vector3 target_direction = target - transform.position;
            float deg = Mathf.Acos(Vector3.Dot(front_direction.normalized, target_direction.normalized)) * Mathf.Rad2Deg;
            RaycastHit hit;
            Physics.Raycast(transform.position, target_direction, out hit);
            {
                if (deg < _angle / 2)
                { return true; }
                else
                { return false; }
            }
        }
        */
}