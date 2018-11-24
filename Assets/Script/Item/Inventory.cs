using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    
    public Player_Health hp;
   
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
            ItemSlot[i] = transform.FindChild("ItemSlot (" + i + ")").gameObject;
            itemImages[i] = ItemSlot[i].transform.FindChild("ItemImage").GetComponentInChildren<Image>();
            counts[i] = ItemSlot[i].GetComponentInChildren<Text>();
        }

        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
    }
    [SerializeField] public int numItemSlots = 20;
    [SerializeField] public GameObject[] ItemSlot;
    [SerializeField] Image[] itemImages;

    public Item[] items;
    Text[] counts;


    int itemCount = 1;

    public void UseItem(ItemInfo i)
    {
        if (i.item.ID == 1)
        {
            if (Input.GetMouseButtonUp(1))
            {
                hp.addPHP.Invoke(50);
                RemoveItem(i.item); 
            }
        }
    }

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
                ItemSlot[i].GetComponent<ItemInfo>().item = itemToAdd;
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
                ItemSlot[i].GetComponent<ItemInfo>().item = null;
                return;
            }
        }
    }
}