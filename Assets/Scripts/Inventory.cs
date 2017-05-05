using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Inventory


{
    public Dictionary<string, int> ItemList { get; private set; }
    private Text inventoryText;
    private static bool UIExists;





    public Inventory()
    {
        ItemList = new Dictionary<string, int>();
        inventoryText = GameObject.Find("InventoryText").GetComponent<Text>();
        UpdateInventoryText();
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

        UpdateInventoryText();
    }

    public void RemoveItem(string item)
    {
        ItemList[item]--;

        if (ItemList[item] <= 0)
        {
            ItemList.Remove(item);
            UpdateInventoryText();
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

    public void UpdateInventoryText()
    {
        inventoryText.text = GetInventoryContents();
    }
}
