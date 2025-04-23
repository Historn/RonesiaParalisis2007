
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAction : MonoBehaviour
{
    public string SceneToLoad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<InteractableDoor>().OnInteractDoor += ActivateDoor;

       // InteractableDoor.OnInteractDoor += ActivateDoor;
    }

    private void ActivateDoor()
    {
        Debug.Log("ActivateDoor: Scene " + SceneToLoad);
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
    }

    private void OnDisable()
    {
        this.GetComponent<InteractableDoor>().OnInteractDoor -= ActivateDoor;
    }
}
