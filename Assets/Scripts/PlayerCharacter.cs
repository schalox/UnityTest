using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    private Rigidbody2D playerBody;

    public float Speed = 3f;

    private float userInputX;
    private float userInputY;

    private float forceX;
    private float forceY;

    void Start()
    {
        // player is the parent object of this script
        playerBody = this.GetComponent<Rigidbody2D>();
    }
    
	void FixedUpdate () {
        // get keyboard or touch screen input
        userInputX = Input.GetAxisRaw("Horizontal");
        userInputY = Input.GetAxisRaw("Vertical");
        
        forceX = userInputX * Speed;
        forceY = userInputY * Speed;

        // move the player according to the user input
        playerBody.velocity = new Vector2(forceX, forceY);
    }
}
