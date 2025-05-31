using DialogueEditor;
using UnityEngine;

public class NPCAction : MonoBehaviour
{
    public NPCConversation[] conversations;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        InteractableNPC.OnAction += NPCDoesSomething;
    }

    private void NPCDoesSomething()
    {
        // Default to first conversation if none matched
        foreach (var convo in conversations)
        {
            if (convo.enabled)
            {
                ConversationManager.Instance.StartConversation(convo);
                Debug.Log($"Started conversation");
                return;
            }
        }
    }

    public void UpdateConversation(string activeStoryEvent)
    {
        foreach (var convo in conversations)
            convo.enabled = false;

        foreach (var convo in conversations)
        {
            if (convo.name.Contains(activeStoryEvent))
            {
                convo.enabled = true;
                break;
            }
        }
    }

    // Update is called once per frame
    void OnDisable()
    {
        InteractableNPC.OnAction -= NPCDoesSomething;
    }
}
