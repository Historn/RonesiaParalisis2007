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

    [SerializeField] LayerMask clickableLayers;

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
        FindInteractable();
    }

    private void FindInteractable()
    {
        newSelectionObject = null;
        RaycastHit hit;        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100, clickableLayers))
        {
            newSelectionObject = hit.collider.gameObject.GetComponent<InteractableObject>();

            if (cursorIsInteractive == false && newSelectionObject)
            {
                InteractiveCursorTexture();
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
            InteractableObject interactable = newSelectionObject;
            if (interactable != null) { interactable.OnClickAction(); }
            newSelectionObject = null;
        }
    }
}
