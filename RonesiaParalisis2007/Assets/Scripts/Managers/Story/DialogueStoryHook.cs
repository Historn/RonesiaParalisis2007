using DialogueEditor;
using UnityEngine;

public class DialogueStoryHook : MonoBehaviour
{
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += OnConversationEnded;
    }

    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= OnConversationEnded;
    }

    void OnConversationEnded()
    {
        StoryManager.Instance.CheckStoryChanged();
    }
}