using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Story/StoryEvent")]
public class StoryEvent : ScriptableObject
{
    public string eventName;

    [Header("Story Variables Required")]
    public int requiredTrust;
    public int requiredKnowledge;
    public int requiredEmpathy;
    public int requiredAuthority;
}
