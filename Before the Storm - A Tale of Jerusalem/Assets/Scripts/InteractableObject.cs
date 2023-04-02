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
