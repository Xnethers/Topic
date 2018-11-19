using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        
        instance = this;
        ItemSlot = new GameObject[numItemSlots];
        itemImages = new Image[numItemSlots];
        items = new Item[numItemSlots];
        counts = new Text[numItemSlots];

        for (int i = 0; i < numItemSlots; i++)
        {
            ItemSlot[i] = GameObject.Find("ItemSlot (" + i + ")");
            itemImages[i] = ItemSlot[i].GetComponentInChildren<Image>();
            counts[i] = ItemSlot[i].GetComponentInChildren<Text>();
        }
    }
    [SerializeField] public int numItemSlots = 20;
    [SerializeField] GameObject[] ItemSlot;
    Image[] itemImages;
    public Item[] items;
    Text[] counts;


    int itemCount = 1;

    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < numItemSlots; i++)
        {
            if (items[i] == itemToAdd)
            {
                if (!itemToAdd.if_only)
                {
                    itemCount += 1;
                    counts[i].text = itemCount.ToString();
                    break;
                }
                else
                { break; }
            }
            else if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.icon;
                itemImages[i].enabled = true;
                return;
            }
        }
    }
    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < numItemSlots; i++)
        {
            if (items[i] == itemToRemove && itemCount > 1)
            {
                if (itemCount == 2)
                {
                    itemCount -= 1;
                    counts[i].text = "";
                }
                else
                {
                    itemCount -= 1;
                    counts[i].text = itemCount.ToString();
                }
            }
            else if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }
}