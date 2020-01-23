using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    public string ItemName { get; set; }
    public float Amount { get; set; }
    public ItemInfo.Type ItemType { get; set; }

    public Item(ItemInfo.Type t, float amount)
    {
        ItemType = t;
        Amount = amount;
        ItemName = ItemInfo.GetItemName(t);
    }



}
