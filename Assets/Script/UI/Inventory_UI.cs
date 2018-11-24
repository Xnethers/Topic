using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{

    public GameObject inventory;

    [SerializeField] Transform notshow;
    [SerializeField] Transform show;
    [SerializeField] bool show_Inventory = false;

    [Space(10), Header("物品資訊顯示")]
    [SerializeField] public GameObject itemInfoPanel;
    [SerializeField] public Text ItemName;
    [SerializeField] public Text ItemDescription;


    // Use this for initialization
    void Start()
    {
        inventory = this.gameObject;
        itemInfoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        { show_Inventory = !show_Inventory; }
        If_show_Inventory();
    }

    void If_show_Inventory()
    {
        if (show_Inventory)
        { inventory.transform.position = show.position; }
        else
        { inventory.transform.position = notshow.position; }
    }

    public void showInventory()
    { show_Inventory = !show_Inventory; }

    public void showiteminfo(ItemInfo i)
    {
        if (i.item != null)
        {
            itemInfoPanel.SetActive(true);
            ItemName.text = i.item.name;
            ItemDescription.text = i.item.Description;
        }
    }
    public void notshowiteminfo()
    {
        itemInfoPanel.SetActive(false);
        ItemName.text = "";
        ItemDescription.text = "";
    }
}
