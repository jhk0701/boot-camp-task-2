using UnityEngine;

public enum CharacterType 
{
    Penguin,
    OldMan,
}

[CreateAssetMenu(fileName = "CharacterData", menuName = "TaskProject/CharacterData")]
public class CharacterData : ScriptableObject
{
    public CharacterType type;
    public float speed;
    public GameObject prefab;
    public Sprite sprite;
}
