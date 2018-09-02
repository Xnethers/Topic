using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new", menuName = "Item")]
public class Item : ScriptableObject
{
    new public string name = "new Item";
    public int ID;
    public Sprite icon;

}
