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
    [SerializeField] string[] participants;
    [SerializeField] DialogueNode root;

    public void StartDialogue(params string[] participants)
    {
        this.participants = participants;
    }
}