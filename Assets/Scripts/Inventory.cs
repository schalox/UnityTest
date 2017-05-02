using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Inventory

	
{
    public Dictionary<string, int> ItemList { get; private set; }
    private Text inventoryText;
	private static bool UIExists;


   
   

    public Inventory()
    {
        ItemList = new Dictionary<string, int>();
        inventoryText = GameObject.Find("InventoryText").GetComponent<Text>();
        updateInventoryText();
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

        updateInventoryText();
    }

    public void RemoveItem(string item)
    {
        ItemList[item]--;

        if (ItemList[item] <= 0)
        {
            ItemList.Remove(item);
            updateInventoryText();
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

    private void updateInventoryText()
    {
        inventoryText.text = GetInventoryContents();
    }
}
