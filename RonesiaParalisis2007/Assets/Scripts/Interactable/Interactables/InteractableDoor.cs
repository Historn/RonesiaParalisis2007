using System;
using UnityEngine;

public class InteractableDoor : InteractableObject
{
    public Action OnInteractDoor { get; set; }

    public override void OnClickAction()
    {
        Debug.Log("You clicked on a door!");
        OnInteractDoor.Invoke();
    }

    private void Start()
    {
        InteractablesManager.AddToInteractablesEvent.Invoke(this);
    }

    private void OnDisable()
    {
        InteractablesManager.RemoveFromInteractablesEvent.Invoke(this);
    }
}
