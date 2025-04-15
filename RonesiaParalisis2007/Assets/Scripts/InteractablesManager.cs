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

    Camera mainCamera;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        AllChildrenWorldToScreenPoint();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void AllChildrenWorldToScreenPoint()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).position = mainCamera.WorldToScreenPoint(transform.GetChild(i).position);
            transform.GetChild(i).localScale = Vector3.one * 100;
        }
    }
}
