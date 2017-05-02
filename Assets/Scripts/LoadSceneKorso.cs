using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneKorso : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D Collider)
    {
        Debug.Log("OSUMA");
        SceneManager.LoadScene("Korso");

    }
}
