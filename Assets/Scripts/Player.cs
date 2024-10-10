using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    // TODO : 시간되면 이것도 분리
    [Header("Player Stat")]
    public float speed = 30f;

    public string PlayerName { get; private set; }
    public GameObject Character { get; private set; }

    [Header("Player UI")]
    [SerializeField] TextMeshProUGUI txtPlayerName;

    public event Action<string> onNameChanged;
    public event Action<GameObject> onCharacterChanged;

    void Start()
    {
        MainManager.Instance.PlayerManager.players.Add(this);    
    }
    
    public void UpdateName(string newName)
    {
        txtPlayerName.text = PlayerName = newName;
        
        onNameChanged?.Invoke(PlayerName);
    }

    public void UpdateCharacter(CharacterType type)
    {
        if (Character != null)
            Destroy(Character);

        Character = MainManager.Instance.CharacterSelection.CreateCharacter(type, transform);

        onCharacterChanged?.Invoke(Character);
    }
}
