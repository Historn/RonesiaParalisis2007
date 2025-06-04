using System;
using UnityEngine;

public class InteractableDoor : InteractableObject
{
    public Action OnInteractDoor;

    public override void OnClickAction()
    {
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
