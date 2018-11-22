using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{

    public Image img_inventory;
    Color _clear = new Color(1, 1, 1, 0);
    Color _open = new Color(1, 1, 1, 1);
    bool show_Inventory = false;

    [Space(10), Header("物品資訊顯示")]
    [SerializeField] public GameObject itemInfoPanel;
    [SerializeField] public Text ItemName;
    [SerializeField] public Text ItemDescription;


    // Use this for initialization
    void Start()
    {
        img_inventory = GetComponent<Image>();
        img_inventory.color = _clear;
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
        { img_inventory.color = _open; }
        else
        { img_inventory.color = _clear; }
    }

    public void showiteminfo()
    {
        itemInfoPanel.SetActive(true);
    }
    public void notshowiteminfo()
    {
        itemInfoPanel.SetActive(false);
        ItemName.text = "";
        ItemDescription.text = "";
    }
}
