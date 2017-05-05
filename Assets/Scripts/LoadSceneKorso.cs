using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneKorso : MonoBehaviour
{
    public string ExitPoint;
    private PlayerCharacter player;

    private void Start()
    {
        player = FindObjectOfType<PlayerCharacter>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("OSUMA");
            SceneManager.LoadScene("Korso");
            player.StartPoint = ExitPoint;
        }
    }
}
