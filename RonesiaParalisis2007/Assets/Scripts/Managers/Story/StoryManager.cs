using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;

    // Story variables - these will track player choices
    [SerializeField] int trust;
    [SerializeField] int knowledge;

    [SerializeField] private StoryEvent currentActiveEvent;
    public StoryEvent[] StoryEvents;

    public delegate void OnStoryChange();
    public static event OnStoryChange onStoryChange;

    PlayerController playerController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void InitializeStoryVariables()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        trust = GameManager.Instance.trust;
        knowledge = GameManager.Instance.knowledge;
        // Load saved variables from PlayerPrefs or a save file
    }

    private void Start()
    {
        // Initialize any starting variables
        InitializeStoryVariables();
        CheckStoryChanged();
    }

    public void IncreaseTrustVariable()
    {
        trust++;
        GameManager.Instance.trust = trust;
    }
    public void IncreaseKnowledgeVariable()
    {
        knowledge++;
        GameManager.Instance.knowledge = knowledge;
    }

    public void DecreaseTrustVariable()
    {
        trust--;
        GameManager.Instance.trust = trust;
    }
    public void DecreaseKnowledgeVariable()
    {
        knowledge--;
        GameManager.Instance.knowledge = knowledge;
    }

    public void CheckStoryChanged()
    {
        foreach (StoryEvent storyEvent in StoryEvents)
        {
            //Debug.Log($"Checking {storyEvent.name}");
            if (trust == storyEvent.requiredTrust &&
                knowledge == storyEvent.requiredKnowledge)
            {
                if (currentActiveEvent != storyEvent)
                {
                    SetActiveStoryEvent(storyEvent);
                }
                return;
            }
        }
        Debug.Log("No story branch matches current variables.");
    }

    private void SetActiveStoryEvent(StoryEvent newEvent)
    {
        Debug.Log($"Setting new active story event: {newEvent.eventName}");

        currentActiveEvent = newEvent;

        onStoryChange?.Invoke();

        UpdateAllNPCConversations();
    }

    public bool IsEventActive(StoryEvent storyEvent)
    {
        return currentActiveEvent == storyEvent;
    }

    private void UpdateAllNPCConversations()
    {
        NPCAction[] npcs = FindObjectsOfType<NPCAction>();
        foreach (var npc in npcs)
        {
            npc.UpdateConversation(currentActiveEvent != null ? currentActiveEvent.eventName : "");
        }
    }

    public void Save(ref StoryManagerSaveData data)
    {
        data.trust = trust;
        data.knowledge = knowledge;
    }

    public void Load(StoryManagerSaveData data)
    {
        trust = data.trust;
        knowledge = data.knowledge;
        CheckStoryChanged();
    }
}

[System.Serializable]
public struct StoryManagerSaveData
{
    public int trust;
    public int knowledge;
}