using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Character
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI txtPlayerName;

    void Start()
    {
        MainManager.Instance.PlayerManager.players.Add(this);    
    }

    public void UpdateName(string newName)
    {
        txtPlayerName.text = Name = newName;
        
        CallNameChangedEvent(newName);
    }

    public void UpdateCharacter(CharacterType type)
    {
        if (CharacterObject != null)
            Destroy(CharacterObject);

        CharacterObject = MainManager.Instance.CharacterSelection.CreateCharacter(type, transform);

        CallCharacterChangedEvent(CharacterObject);
    }
}
