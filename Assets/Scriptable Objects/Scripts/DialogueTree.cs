using System;
using UnityEngine;

[Serializable]
public class DialogueNode
{
    public string name;
    public int participantId;
    [TextArea] public string content;
    public DialogueNode[] response;
}

[CreateAssetMenu(fileName = "DialogueTree", menuName = "TaskProject/DialogueTree", order = 0)]
public class DialogueTree : ScriptableObject 
{
    public string[] Participants{ get; private set; }
    [SerializeField] DialogueNode root;
    public DialogueNode CurrentNode { get; private set; }

    public void InitializeDialogue(params string[] participants)
    {
        Participants = participants;
        CurrentNode = root;
    }

    public void Next(int choice = 0)
    {
        if(CurrentNode.response.Length == 0)
            return;

        CurrentNode = CurrentNode.response[choice];
    }

    public bool IsLast()
    {
        return CurrentNode.response.Length == 0;
    }
}