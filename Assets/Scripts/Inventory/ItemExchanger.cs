using UnityEngine;
using System;

public class ItemExchanger : MonoBehaviour
{
    public ItemData[] requiredItems;
    public ItemData itemGiven;

    public void ExchangeItems()
    {
        var inventory = Inventory.Instance.Data;

        foreach (ItemData item in requiredItems)
        {
            var target = Array.BinarySearch(inventory, item);
        }
    }
}
