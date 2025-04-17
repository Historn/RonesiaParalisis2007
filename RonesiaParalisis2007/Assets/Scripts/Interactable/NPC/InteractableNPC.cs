using UnityEngine;
using System;

public class InteractableNPC : InteractableObject
{
    public static Action OnAction;

    public override void OnClickAction()
    {
        OnAction.Invoke();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractablesManager.AddToInteractablesEvent.Invoke(this); // CHANGE TO OnEnable?
    }

    // Update is called once per frame
    void OnDisable()
    {
        InteractablesManager.RemoveFromInteractablesEvent.Invoke(this);
    }
}
