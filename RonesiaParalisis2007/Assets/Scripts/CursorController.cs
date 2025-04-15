using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    InputAction interactAction;

    [SerializeField] InteractablesManager interactablesManager;

    [SerializeField] Texture2D[] cursorTextures;

    Cursor cursor;

    [SerializeField]
    InteractableObject newSelectionObject;
    InteractableObject currentSelectionObject;

    public static Action MakeCursorDefault;
    public static Action MakeCursorInteractive;
    bool cursorIsInteractive = false;

    public float distanceThreshold;

    private void Awake()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        interactAction.started += _ => StartedClick();
        interactAction.performed += _ => EndedClick();

        MakeCursorDefault += DefaultCursorTexture;
        MakeCursorInteractive += InteractiveCursorTexture;
    }

    private void Update()
    {
        FindInteractableWithinDistanceThreshold();
    }

    private void FindInteractableWithinDistanceThreshold()
    {
        newSelectionObject = null;

        for (int itemIndex = 0; itemIndex < interactablesManager.Interactables.Count; itemIndex++)
        {
            Vector3 fromMouseToInteractableOffset = interactablesManager.Interactables[itemIndex].transform.position
                - new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);

            float sqrMag = fromMouseToInteractableOffset.sqrMagnitude;

            if (sqrMag < distanceThreshold * distanceThreshold)
            {
                newSelectionObject = interactablesManager.Interactables[itemIndex];

                if (cursorIsInteractive == false)
                {
                    InteractiveCursorTexture();
                }
                break;
            }
        }

        if (currentSelectionObject != newSelectionObject)
        {
            currentSelectionObject = newSelectionObject;
            DefaultCursorTexture();
        }
    }

    private void DefaultCursorTexture()
    {
        cursorIsInteractive = false;
        Cursor.SetCursor(default, default, default);
    }

    private void InteractiveCursorTexture()
    {
        cursorIsInteractive = true;
        Vector2 hotspot = new Vector2(cursorTextures[0].width / 2, 0);

        switch (newSelectionObject.interactType)
        {
            case InteractType.Talk:
                {
                    Cursor.SetCursor(cursorTextures[1], hotspot, CursorMode.Auto);
                }
                break;
            case InteractType.Grab:
                {
                    Cursor.SetCursor(cursorTextures[2], hotspot, CursorMode.Auto);
                }
                break;
            case InteractType.None:
                {
                    Cursor.SetCursor(cursorTextures[0], hotspot, CursorMode.Auto);
                }
                break;
            default:
                break;
        }

        
    }

    private void StartedClick()
    {

    }
    
    private void EndedClick()
    {
        OnClickInteractable();
    }

    private void OnClickInteractable()
    {
        if (newSelectionObject != null)
        {
            InteractableObject interactable = newSelectionObject.gameObject.GetComponent<InteractableObject>();
            if (interactable != null) { interactable.OnClickAction(); }
            newSelectionObject = null;
        }
    }
}
