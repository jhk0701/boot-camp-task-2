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
    [SerializeField] GameObject panel;
    [SerializeField] Transform characterList;

    [Header("Prefab")]
    [SerializeField] Button prefCharacterCard;

    public event Action<CharacterType> onCharacterChanged;


    void Start()
    {
        foreach (CharacterData data in characterSelect.datas)
        {
            Button btn = Instantiate(prefCharacterCard, characterList);
            btn.transform.GetChild(0).GetComponent<Image>().sprite = data.sprite;
            btn.onClick.AddListener(()=>{ OnClickCharacterCard(data.type); });
        }

        onCharacterChanged += (CharacterType type) => 
        {
            if(MainManager.Instance.PlayerManager.Player == null)
                return;
                
            MainManager.Instance.PlayerManager.Player.UpdateCharacter(type);
        };
    }

    public void PopUp()
    {
        panel.gameObject.SetActive(true);
    }
    
    public void Close()
    {
        panel.gameObject.SetActive(false);
    }


    public void OnClickCharacterCard(CharacterType type)
    {
        CurrentCharacterType = type;

        onCharacterChanged?.Invoke(type);

        Close();
    }
}
