using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerCharacterSelector : MonoBehaviour, IPopUpable
{
    CharacterSelection characterSelect => MainManager.Instance.CharacterSelection;
    
    public CharacterType CurrentCharacterType = CharacterType.Penguin;
    [SerializeField] Transform characterList;

    [Header("Prefab")]
    [SerializeField] Button prefCharacterCard;

    public Action onCharacterChanged;

    void Start()
    {
        foreach (CharacterData data in characterSelect.datas)
        {
            Button btn = Instantiate(prefCharacterCard, characterList);
            btn.transform.GetChild(0).GetComponent<Image>().sprite = data.sprite;
            btn.onClick.AddListener(()=>{ OnClickCharacterCard(data.type); });
        }
    }

    public void PopUp()
    {
        characterList.gameObject.SetActive(true);
    }

    public void OnClickCharacterCard(CharacterType type)
    {
        characterList.gameObject.SetActive(false);
        
        CurrentCharacterType = type;

        onCharacterChanged?.Invoke();
    }
}
