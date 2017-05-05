using UnityEngine;

public class StartingPoint : MonoBehaviour
{
    public string PointName;

    void Start()
    {
        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();

        if (player.StartPoint == PointName)
        {
            Debug.Log("Moving the player to " + transform.position.ToString());
            Camera camera = FindObjectOfType<Camera>();
            player.transform.position = transform.position;
            camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        }

    }
}
