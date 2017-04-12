using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Inventory
{
    public Dictionary<string, int> ItemList { get; private set; }

    public Inventory()
    {
        ItemList = new Dictionary<string, int>();
    }

    public void AddItem(string item)
    {
        if (ItemList.ContainsKey(item))
        {
            ItemList[item]++;
        }
        else
        {
            ItemList.Add(item, 1);
        }
    }

    public void RemoveItem(string item)
    {
        ItemList[item]--;

        if (ItemList[item] <= 0)
        {
            ItemList.Remove(item);
        }
    }

    public string GetInventoryContents()
    {
        StringBuilder inventoryText = new StringBuilder();

        foreach (var item in ItemList)
        {
            inventoryText.AppendLine(string.Format("{0}: {1}", item.Key, item.Value));
        }

        return inventoryText.ToString();
    }
}
