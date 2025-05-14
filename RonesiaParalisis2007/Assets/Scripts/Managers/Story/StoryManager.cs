using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using DialogueEditor;
using System;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;

    // Story variables - these will track player choices
    [SerializeField] private Dictionary<string, int> storyVariables = new Dictionary<string, int>();

    public UnityEvent<string, int> UpdateStory;

    [Header("Dialogue Branches")]
    public List<Branch> branches = new List<Branch>();

    public static Action OnStoryChange;

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
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
        return storyVariables[storyVariable];
    }

    public void IncreaseStoryVariable(string storyVariableName)
    {
        if (storyVariables.ContainsKey(storyVariableName))
        {
            storyVariables[storyVariableName] += 1;
            CheckStoryChanged();
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
            storyVariables[storyVariableName] -= 1;
            CheckStoryChanged();
            Debug.Log($"Story Variable: {storyVariableName} increased");
        }
        else
        {
            Debug.Log("Story Variable: {storyVariableName} does not exist");
        }
    }

    // Cada vez que cambia una variable mirar si hay que cambiar de rama?
    void CheckStoryChanged()
    {
        //if (changed) { }
    }

    public void Save(ref StoryManagerSaveData data)
    {
        data.storyVariables = storyVariables;
    }

    public void Load(StoryManagerSaveData data)
    {
        storyVariables = data.storyVariables;
    }
}

[System.Serializable]
public struct StoryManagerSaveData
{
    public Dictionary<string, int> storyVariables;
}