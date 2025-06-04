using DialogueEditor;
using UnityEngine;

public class NPCAction : MonoBehaviour
{
    public NPCConversation[] conversations;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        this.GetComponent<InteractableNPC>().OnAction += NPCDoesSomething;
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
        Debug.Log(name);
        foreach (var convo in conversations)
            convo.enabled = false;

        foreach (var convo in conversations)
        {
            if (convo.name.Contains(activeStoryEvent))
            {
                convo.enabled = true;
                return;
            }
        }

        if (conversations.Length > 0) conversations[0].enabled = true;
    }

    // Update is called once per frame
    void OnDisable()
    {
        this.GetComponent<InteractableNPC>().OnAction -= NPCDoesSomething;
    }
}
