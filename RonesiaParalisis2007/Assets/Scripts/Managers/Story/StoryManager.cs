using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;

    // Story variables - these will track player choices
    [SerializeField] private Dictionary<string, int> storyVariables = new Dictionary<string, int>();

    [SerializeField] private StoryEvent currentActiveEvent;
    public StoryEvent[] StoryEvents;

    public delegate void OnStoryChange();
    public static event OnStoryChange onStoryChange;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Initialize any starting variables
            InitializeStoryVariables();
        }
        else
        {
            Destroy(gameObject);
        }
        CheckStoryChanged();
    }

    private void InitializeStoryVariables()
    {
        // Initial values
        storyVariables["trust"] = 0;
        storyVariables["knowledge"] = 0;
        storyVariables["empathy"] = 0;
        storyVariables["authority"] = 0;

        // Load saved variables from PlayerPrefs or a save file
    }

    public int GetStoryVariable(string storyVariable)
    {
        if (storyVariables.TryGetValue(storyVariable, out int value))
            return value;

        Debug.LogWarning($"Story variable '{storyVariable}' not found.");
        return 0;
    }

    public void IncreaseStoryVariable(string storyVariableName)
    {
        if (storyVariables.ContainsKey(storyVariableName))
        {
            storyVariables[storyVariableName]++;
            Debug.Log($"Story Variable: {storyVariableName} increased");
        }
        else
        {
            Debug.Log($"Story Variable: {storyVariableName} does not exist");
        }
    }

    public void DecreaseStoryVariable(string storyVariableName)
    {
        if (storyVariables.ContainsKey(storyVariableName))
        {
            storyVariables[storyVariableName]--;
            Debug.Log($"Story Variable: {storyVariableName} increased");
        }
        else
        {
            Debug.Log("Story Variable: {storyVariableName} does not exist");
        }
    }

    public void CheckStoryChanged()
    {
        foreach (StoryEvent storyEvent in StoryEvents)
        {
            Debug.Log($"Checking {storyEvent.name}");
            if (storyVariables["trust"] == storyEvent.requiredTrust &&
                storyVariables["knowledge"] == storyEvent.requiredKnowledge &&
                storyVariables["empathy"] == storyEvent.requiredEmpathy &&
                storyVariables["authority"] == storyEvent.requiredAuthority)
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
        data.storyVariables = storyVariables;
    }

    public void Load(StoryManagerSaveData data)
    {
        storyVariables = data.storyVariables;
        CheckStoryChanged();
    }
}

[System.Serializable]
public struct StoryManagerSaveData
{
    public Dictionary<string, int> storyVariables;
}