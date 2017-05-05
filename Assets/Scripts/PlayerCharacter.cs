using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private Rigidbody2D playerBody;

    public float Speed = 3f;

    private float userInputX;
    private float userInputY;

    private float forceX;
    private float forceY;

    private static bool playerExists;

    public Inventory Inventory { get; private set; }

    private BottleMission bottleMission;

    public string StartPoint;

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

            // move the player according to the user input
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
        if (otherObject.gameObject.CompareTag("Item"))
        {
            Item item = otherObject.gameObject.GetComponent<Item>();
            Debug.Log("Collision with an item named " + item.Name);
            Inventory.AddItem(item.Name);
            otherObject.gameObject.SetActive(false);

            string itemName = otherObject.GetComponent<Item>().Name;

            if (bottleMission.Status == MissionStatus.Active && itemName == "Beer Bottle")
            {
                bottleMission.UpdateMission();
            }
        }
    }
}
