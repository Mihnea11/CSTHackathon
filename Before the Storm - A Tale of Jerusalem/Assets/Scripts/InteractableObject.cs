using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : Interactable
{
    [SerializeField] 
    private GameObject itemDescriptions;
    [SerializeField]
    private Button closeButton;
    [SerializeField]
    private GameObject pointsDisplay;
    [SerializeField]
    private int value; 

    private Transform describedItem;


    public override void OnFocus()
    {
        Debug.Log(gameObject.name);
    }

    public override void OnInteract()
    {
        FirstPersonController.CanMove = false;

        itemDescriptions.SetActive(true);
        describedItem = itemDescriptions.transform.Find(gameObject.name + "-Information");

        describedItem.gameObject.SetActive(true);

        closeButton.onClick.AddListener(CloseButtonClick);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        FirstPersonController.Points += value;
        value = 0;

        pointsDisplay.GetComponent<Text>().text = "Points: " + FirstPersonController.Points.ToString();
    }

    public override void OnLoseFocus()
    {
        Debug.Log("Left " + gameObject.name);
    }

    public void CloseButtonClick()
    {
        describedItem.gameObject.SetActive(false);
        itemDescriptions.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        FirstPersonController.CanMove = true;
    }
}
