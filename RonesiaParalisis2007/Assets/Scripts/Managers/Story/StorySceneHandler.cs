using UnityEngine;

public class StorySceneHandler : MonoBehaviour
{
    public StoryEvent storyEvent;

    public GameObject[] sceneObjectsToEnable;
    public GameObject[] sceneObjectsToDisable;

    private void OnEnable()
    {
        StoryManager.onStoryChange += CheckIfShouldActivate;
    }

    private void OnDisable()
    {
        StoryManager.onStoryChange -= CheckIfShouldActivate;
    }

    public void CheckIfShouldActivate()
    {
        if (StoryManager.Instance.IsEventActive(storyEvent))
        {
            foreach (var obj in sceneObjectsToEnable)
                obj.SetActive(true);

            foreach (var obj in sceneObjectsToDisable)
                obj.SetActive(false);
        }
        else
        {
            foreach (var obj in sceneObjectsToEnable)
                obj.SetActive(false);
        }
    }
}
