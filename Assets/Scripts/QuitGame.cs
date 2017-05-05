using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => LoadGame());
    }

    public void LoadGame()
    {
        Application.Quit();
    }
}
