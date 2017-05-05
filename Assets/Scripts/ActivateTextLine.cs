using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextLine : MonoBehaviour
{

    public TextAsset theText;
    public int startLine;
    public int endLine;
    private DialogManager theTextBox;

    public bool destroyWhenActivated;
    public bool requireButtonPress;
    private bool waitforPress;

    // Use this for initialization
    void Start()
    {
        theTextBox = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitforPress && Input.GetKeyDown(KeyCode.Return))
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (requireButtonPress)
            {
                waitforPress = true;
                return;
            }

            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            waitforPress = false;
        }
    }
}
