using DialogueEditor;
using UnityEngine;

public class NPCAction : MonoBehaviour
{
    public NPCConversation conversation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractableNPC.OnAction += NPCDoesSomething;
    }

    private void NPCDoesSomething()
    {
        ConversationManager.Instance.StartConversation(conversation);
        //transform.position.Set(0, 3, 0);
    }

    // Update is called once per frame
    void OnDisable()
    {
        InteractableNPC.OnAction -= NPCDoesSomething;
    }
}
