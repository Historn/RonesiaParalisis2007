using System;
using UnityEngine;

public class InteractableDoor : InteractableObject
{
    public static Action OnEnterBuilding;

    public override void OnClickAction()
    {
        Debug.Log("You clicked on the door!");
        OnEnterBuilding.Invoke();
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
