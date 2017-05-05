using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingZone : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Moving the player to " + transform.position.ToString());
        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();
        Camera camera = FindObjectOfType<Camera>();
        player.transform.position = transform.position;
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
    }
}
