using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interactable
{
    public override void OnFocus()
    {
        Debug.Log(gameObject.name);
    }

    public override void OnInteract()
    {
        Debug.Log("Touched " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        Debug.Log("Left " + gameObject.name);
    }
}
