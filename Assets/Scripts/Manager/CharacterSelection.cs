using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    // 데이터 모음
    public CharacterData[] datas;
    // 검색용
    public Dictionary<CharacterType, CharacterData> Map {get; private set;}


    void Awake()
    {
        Map = new Dictionary<CharacterType, CharacterData>();

        foreach (CharacterData data in datas)
        {
            Map.Add(data.type, data);
        }
    }   
    
    public GameObject CreateCharacter(CharacterType type = CharacterType.Penguin)
    {
        return Instantiate(Map[type].prefab);
    }

    public GameObject CreateCharacter(CharacterType type, Transform parent)
    {
        return Instantiate(Map[type].prefab, parent);
    }
}