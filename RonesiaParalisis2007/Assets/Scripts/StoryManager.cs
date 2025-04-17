using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;

    // Story variables - these will track player choices
    [SerializeField] private Dictionary<string, int> storyVariables = new Dictionary<string, int>();

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
}
