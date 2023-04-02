using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InteractableHuman : Interactable
{ 
    [SerializeField] 
    private GameObject dialoguePanel;
    [SerializeField] 
    private List<string> dialogueLines;
    [SerializeField]
    private GameObject dialogueLine;
    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private bool isMinigame = false;
    [SerializeField]
    private GameObject minigameObject;

    private int currentLine = 0;


    public override void OnFocus()
    {
        Debug.Log(gameObject.name);
    }

    public override void OnInteract()
    {
        FirstPersonController.CanMove = false;

        currentLine = 0;
        nextButton.onClick.AddListener(NextButtonClick);
        dialoguePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        dialogueLine.GetComponent<Text>().text = dialogueLines[currentLine];
    }

    public override void OnLoseFocus()
    {
        Debug.Log("Left " + gameObject.name);
    }

    public void NextButtonClick()
    {
        Debug.Log("Click");
        if(currentLine + 1 < dialogueLines.Count) 
        {
            currentLine++;
            dialogueLine.GetComponent<Text>().text = dialogueLines[currentLine];
        }
        else if(currentLine + 1 == dialogueLines.Count)
        {
            FirstPersonController.CanMove = true;
            dialoguePanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            nextButton.onClick.RemoveAllListeners();

            if(isMinigame == true)
            {
                StartMinigame();
            }
        }
    }

    private void StartMinigame()
    {
        minigameObject.SetActive(true);

    }
}
