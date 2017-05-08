using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Inventory


{
    /// <summary>
    /// Dictionary to hold the items.
    /// </summary>
    public Dictionary<string, int> ItemList { get; private set; }

    /// <summary>
    /// Text box which shows the inventory to the player.
    /// </summary>
    private Text inventoryText;
    private static bool UIExists;





    public Inventory()
    {
        ItemList = new Dictionary<string, int>();
        inventoryText = GameObject.Find("InventoryText").GetComponent<Text>();
        UpdateInventoryText();
    }

    /// <summary>
    /// Add an item to the inventory.
    /// </summary>
    /// <param name="item">Item to add.</param>
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

    /// <summary>
    /// Remove an item from the inventory.
    /// </summary>
    /// <param name="item">Item to remove.</param>
    public void RemoveItem(string item)
    {
        ItemList[item]--;

        if (ItemList[item] <= 0)
        {
            ItemList.Remove(item);
            UpdateInventoryText();
        }
    }

    /// <summary>
    /// Get inventory's contents in text form.
    /// </summary>
    /// <returns>String representation of the inventory.</returns>
    public string GetInventoryContents()
    {
        StringBuilder inventoryText = new StringBuilder();

        foreach (var item in ItemList)
        {
            inventoryText.AppendLine(string.Format("{0}: {1}", item.Key, item.Value));
        }

        return inventoryText.ToString();
    }

    /// <summary>
    /// Update the inventory text on the screen.
    /// </summary>
    public void UpdateInventoryText()
    {
        inventoryText.text = GetInventoryContents();
    }
}
