using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesManager : MonoBehaviour
{
    [SerializeField] 
    private List<InteractableObject> interactables;

    public List<InteractableObject> Interactables
    {
        get => interactables;
    }

    public static Action<InteractableObject> AddToInteractablesEvent;
    public static Action<InteractableObject> RemoveFromInteractablesEvent;

    private void Awake()
    {
        AddToInteractablesEvent += AddToListOfInteractables;
        RemoveFromInteractablesEvent += RemoveFromListOfInteractables;
    }

    private void AddToListOfInteractables(InteractableObject obj)
    {
        interactables.Add(obj);
    }

    private void RemoveFromListOfInteractables(InteractableObject obj)
    {
        interactables.Remove(obj);
    }
}
