using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Search_Item : MonoBehaviour
{
    public Image UI;
    public Flowchart _flowchart;
    public float distance;

    [SerializeField, Header("探索物品")]
    private bool is_search;
    public ItemPickup _itemup;
    GameObject _object;

    //RaycastHit hit;
    [SerializeField]
    private Collider[] hit = new Collider[3];
    private Collider nearestobject;



    // Update is called once per frame
    void Update()
    {
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, 1 << LayerMask.NameToLayer("Item")))
        hit = Physics.OverlapSphere(transform.position, distance, 1 << LayerMask.NameToLayer("Item"));

        npc = Physics.OverlapSphere(transform.position, distance, 1 << LayerMask.NameToLayer("NPC"));

        //Debug.Log("CanSearchItem = " + CanSearchItem());
        //Debug.Log("CanTalktoNPC = " + CanTalktoNPC());

        if (hit.Length > 1)
        { Debug.Log("object overlapping"); }

        if (CanSearchItem())
        {
            UI.enabled = true;
            GetItemMessage();
            if (Input.GetKeyDown(KeyCode.F))
            { is_search = true; }
        }
        else if (CanTalktoNPC())
        {
            UI.enabled = true;
            talk();
            if (Input.GetKeyDown(KeyCode.F))
            { is_talk = true; }
        }
        else
        {
            hit = null;
            UI.enabled = false;
            is_search = false;
        }
    }

    public bool CanSearchItem()
    {
        if (hit.Length > 0)
        {
            _itemup = hit[0].GetComponent<ItemPickup>();
            return true;
        }
        else
        { return false; }
    }

    void setSearchlist()
    {
        _itemup = hit[0].GetComponent<ItemPickup>();
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
            }
            else if (_itemup.item.ID > 5 && _itemup.item.ID < 20)
            {
                _flowchart.ExecuteBlock("Get_Note");
                _itemup.Invoke("PickUp", 0);
            }
            else if (_itemup.item.ID > 0020)
            {
                _flowchart.SetStringVariable("classroom", _itemup.item.name);
                _flowchart.ExecuteBlock("Get_Key");
                _itemup.PickUp();
            }
        }

    }

    void GetClosest()
    {
        for (int k = 0; k < hit.Length; k++)
        {
            { }
        }
    }

    [SerializeField, Header("NPC對話")]

    private bool is_talk;
    public NPC _npc;

    [SerializeField]
    private Collider[] npc = new Collider[1];

    public bool CanTalktoNPC()
    {
        if (npc.Length > 0)
        {
            _npc = npc[0].GetComponent<NPC>();
            return true;
        }
        else
        { return false; }
    }

    public void talk()
    {
        if (is_talk)
        {
            string NPC_number = _flowchart.GetIntegerVariable("NPC").ToString();
            _flowchart.ExecuteBlock("NPC" + NPC_number);
        }
    }

}