using UnityEngine;

public enum CharacterType 
{
    Penguin,
    Boy1,
    Boy2,
    Girl1,
    Girl2,
}

[CreateAssetMenu(fileName = "CharacterData", menuName = "TaskProject/CharacterData")]
public class CharacterData : ScriptableObject
{
    public CharacterType type;
    public GameObject prefab;
    public Sprite sprite;
}
