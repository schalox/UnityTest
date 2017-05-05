using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneMain : MonoBehaviour
{
    public string ExitPoint;
    private PlayerCharacter player;

    private void Start()
    {
        player = FindObjectOfType<PlayerCharacter>();
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        Debug.Log("OSUMA");
        SceneManager.LoadScene("Main");
        player.StartPoint = ExitPoint;
    }
}
