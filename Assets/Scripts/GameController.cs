using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private PlayerCharacter playerCharacter;
    private Text inventoryText;
    
	void Start () {
        playerCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        inventoryText = GameObject.Find("InventoryText").GetComponent<Text>();
	}
	
	void Update () {
        inventoryText.text = playerCharacter.Inventory.GetInventoryContents();
	}
}
