using UnityEngine;
using System;


public class Character : MonoBehaviour
{
    [Header("Stat")]
    public float speed = 30f;

    public string Name { get; protected set; }
    public GameObject CharacterObject { get; protected set; }

    public event Action<string> OnNameChangedEvent;
    public event Action<GameObject> OnCharacterChangedEvent;


    public void CallNameChangedEvent(string newName)
    {
        OnNameChangedEvent?.Invoke(newName);
    }    
    
    public void CallCharacterChangedEvent(GameObject newCharacter)
    {
        OnCharacterChangedEvent?.Invoke(newCharacter);
    }
}