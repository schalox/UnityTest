using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    private GameObject player;

    public float Speed = 6f;
    public Inventory Inventory { get; private set; }
	
    void Start()
    {
        // player is the parent object of this script
        player = this.gameObject;
        Inventory = new Inventory();
    }
    
	void Update () {
        // get keyboard or touch screen input
        float userInputX = Input.GetAxis("Horizontal");
        float userInputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(userInputX * Speed, userInputY * Speed);

        // move the player according to the user input
        player.transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.CompareTag("Item"))
        {
            Item item = otherObject.gameObject.GetComponent<Item>();
            Debug.Log("Collision with an item named " + item.Name);
            Inventory.AddItem(item.Name);
            otherObject.gameObject.SetActive(false);
        }
    }
}
