using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    /// <summary>
    /// The panel which contains the text field.
    /// </summary>
    public GameObject textBox;

    /// <summary>
    /// The text field where the dialog is shown.
    /// </summary>
    public Text theText;

    /// <summary>
    /// The text file where the dialog is read from.
    /// </summary>
    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public PlayerCharacter player;
    public bool isActive;

    public bool stopPlayerMovement;


    void Start()
    {
        player = FindObjectOfType<PlayerCharacter>();

        Debug.Log("Found player: " + player.name);

        if (textFile != null)
        {
            Debug.Log("Found the text file: " + textFile.name);
            textLines = (textFile.text.Split('\n'));
        }


        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            Debug.Log("Enabling the text box");
            EnableTextBox();
        }
        else
        {
            Debug.Log("Disabling the text box");
            DisableTextBox();
        }
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        theText.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLine += 1;
        }

        if (currentLine > endAtLine)
        {
            DisableTextBox();
        }


    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        if (stopPlayerMovement)
        {
            player.canMove = false;
        }


    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        player.canMove = true;


    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
