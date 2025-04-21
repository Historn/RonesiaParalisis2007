using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAction : MonoBehaviour
{
    public string SceneToLoad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractableDoor.OnInteractDoor += ActivateDoor;
    }

    private void ActivateDoor()
    {
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
    }

    private void OnDisable()
    {
        InteractableDoor.OnInteractDoor -= ActivateDoor;
    }
}
