using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    NavMeshAgent agent;

    InputAction interactAction;

    [SerializeField] InteractablesManager interactablesManager;

    [SerializeField] Texture2D[] cursorTextures;

    Cursor cursor;

    [SerializeField] InteractableObject newSelectionObject;
    [SerializeField] InteractableObject currentSelectionObject;
    InteractableObject clickedInteractable;
    float distance = 100f;
    [SerializeField] float interactionDistance = 100f;


    public static Action MakeCursorDefault;
    public static Action MakeCursorInteractive;
    bool cursorIsInteractive = false;

    [SerializeField] LayerMask clickableLayers;

    IEnumerator moveToInteract;

    private void Awake()
    {
        moveToInteract = MoveToInteract();

        interactAction = InputSystem.actions.FindAction("Interact");
        interactAction.started += _ => StartedClick();
        interactAction.performed += _ => EndedClick();

        MakeCursorDefault += DefaultCursorTexture;
        MakeCursorInteractive += InteractiveCursorTexture;

        agent = GetComponent<NavMeshAgent>();
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
        if (clickedInteractable != null) distance = Vector3.Distance(transform.position, clickedInteractable.transform.position);
    }

    private void DefaultCursorTexture()
    {
        cursorIsInteractive = false;
        Cursor.SetCursor(cursorTextures[0], default, default);
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
            case InteractType.ChangeScene:
                {
                    Cursor.SetCursor(cursorTextures[3], hotspot, CursorMode.Auto);
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
            StopCoroutine(moveToInteract);

            clickedInteractable = newSelectionObject;
            agent.destination = clickedInteractable.transform.position;

            StartCoroutine(moveToInteract);
            newSelectionObject = null;
        }
    }

    IEnumerator MoveToInteract()
    {
        while (distance > interactionDistance)
        {
            yield return null;
        }
        
        if (clickedInteractable != null)
        {
            agent.ResetPath();
            agent.isStopped = true;
            clickedInteractable.OnClickAction();
            clickedInteractable = null;
        }
    }
}
