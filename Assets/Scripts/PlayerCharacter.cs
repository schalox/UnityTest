using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    private GameObject player;

    public float Speed = 6f;
	
    void Start()
    {
        // player is the parent object of this script
        player = this.gameObject;
    }
    
	void Update () {
        // get keyboard or touch screen input
        float userInputX = Input.GetAxis("Horizontal");
        float userInputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(userInputX * Speed, userInputY * Speed);

        // move the player according to the user input
        player.transform.Translate(movement);
    }
}
