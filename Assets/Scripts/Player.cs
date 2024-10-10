using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    [Header("Player Stat")]
    public float speed = 30f;

    public string PlayerName { get; private set; }
    public GameObject Character { get; private set; }

    [Header("Player UI")]
    [SerializeField] TextMeshProUGUI txtPlayerName;

    public event Action<string> onNameChanged;
    public event Action<GameObject> onCharacterChanged;

    
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
        
        AnimationController animCtrl = GetComponent<AnimationController>();
        animCtrl.AssignAnimator(Character.GetComponent<Animator>());

        Debug.Log("UpdateCharacter");

        onCharacterChanged?.Invoke(Character);
    }
}
