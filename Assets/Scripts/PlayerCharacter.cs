using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private Rigidbody2D playerBody;

    /// <summary>
    /// Player's speed.
    /// </summary>
    public float Speed = 3f;

    private float userInputX;
    private float userInputY;

    /// <summary>
    /// Horizontal force affecting the player.
    /// </summary>
    private float forceX;

    /// <summary>
    /// Vertical force affecting the player.
    /// </summary>
    private float forceY;

    /// <summary>
    /// Does the player exist?
    /// </summary>
    private static bool playerExists;

    /// <summary>
    /// Player's inventory.
    /// </summary>
    public Inventory Inventory { get; private set; }

    private BottleMission bottleMission;

    public string StartPoint;

    /// <summary>
    /// Can the player move?
    /// </summary>
    public bool canMove;

    //void Awake() {
    //	DontDestroyOnLoad (gameObject);
    //}

    void Start()
    {
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        // player is the parent object of this script
        playerBody = this.GetComponent<Rigidbody2D>();
        Inventory = new Inventory();

        bottleMission = FindObjectOfType<BottleMission>();

        canMove = true;
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            // get keyboard or touch screen input
            userInputX = Input.GetAxisRaw("Horizontal");
            userInputY = Input.GetAxisRaw("Vertical");

            forceX = userInputX * Speed;
            forceY = userInputY * Speed;

            // set the player's velocity according to the user input
            playerBody.velocity = new Vector2(forceX, forceY);


            Inventory.UpdateInventoryText();
        }
        else
        {
            playerBody.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        // if the player collides with an item, add it to the player's inventory
        if (otherObject.gameObject.CompareTag("Item"))
        {
            Item item = otherObject.gameObject.GetComponent<Item>();
            Debug.Log("Collision with an item named " + item.Name);

            Inventory.AddItem(item.Name);
            otherObject.gameObject.SetActive(false);

            string itemName = otherObject.GetComponent<Item>().Name;

            if (bottleMission.Status == MissionStatus.Active && itemName == "Beer Bottle")
            {
                // update bottle mission's status text
                bottleMission.UpdateMission();
            }
        }
    }
}
