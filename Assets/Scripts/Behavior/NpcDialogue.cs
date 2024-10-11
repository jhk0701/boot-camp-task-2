using UnityEngine;

[RequireComponent(typeof(NpcInteraction))]
[RequireComponent(typeof(NonPlayer))]
public class NpcDialogue : MonoBehaviour
{
    NonPlayer npc;
    InteractableObject interaction;
    
    [SerializeField] DialogueTree dialogue;
    [SerializeField] DialoguePlayer dialoguePlayer;
    bool isDialoguePlaying = false;

    void Awake()
    {
        interaction = GetComponent<InteractableObject>();     
        npc = GetComponent<NonPlayer>();
    }

    void Start()
    {
        interaction.Interact += ShowDialogue;
        interaction.OnEndInteract += CloseDialogue;
    }

    void ShowDialogue()
    {
        if (isDialoguePlaying) return;
        if (dialoguePlayer == null) return;
        
        isDialoguePlaying = true;

        dialogue.InitializeDialogue(npc.Name, interaction.NearbyPlayer.Name);
        dialoguePlayer.Play(dialogue);
    }

    void CloseDialogue()
    {
        dialoguePlayer.Close();

        isDialoguePlaying = false;
    }
}