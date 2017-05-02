using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => LoadGame());
    }

	public void LoadGame()
    {
        SceneManager.LoadScene(0);
    }
}
