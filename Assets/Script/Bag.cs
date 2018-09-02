using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    public static int Lingshi;
    public Image[] Bag_array = new Image[5];

    public Key[] keylist = new Key[5];

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i <= Bag_array.Length; i++)
        { }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Lingshi > 0)
            {
                Lingshi--;
                Player_Health.NowHP += 30;
            }
        }
    }

    public void Get_key(Key _key)
    {
        for (int j = 0; j <= Bag_array.Length; j++)
        {
            if (keylist[j] == null)
            {
                keylist[j] = _key;
                Bag_array[j].sprite = keylist[j].icon;
                _key.showInInventory = true;
                break;
            }
            else { }
        }
    }

    void use_key(Key _key)
    {

    }
}
