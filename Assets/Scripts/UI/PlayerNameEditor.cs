using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;

public class PlayerNameEditor : MonoBehaviour, IPopUpable
{
    public string Name {get; private set;}
    string playerNameExpression = @"^[가-힣a-zA-Z0-9]{2,10}$";

    [SerializeField] Transform panel;
    [SerializeField] TMP_InputField inputFieldPlayerName;
    [SerializeField] GameObject playerNameMatched;
    
    public void PopUp()
    {
        panel.gameObject.SetActive(true);
        
        if(MainManager.Instance.PlayerManager.Player == null)
            inputFieldPlayerName.text = Name = "";
        else
            inputFieldPlayerName.text = Name = MainManager.Instance.PlayerManager.Player.PlayerName;
    }

    public void Close()
    {
        if(!IsVaildName(Name))
            return;

        MainManager.Instance.PlayerManager.Player.UpdateName(Name);
        panel.gameObject.SetActive(false);
    }

    public void OnPlayerNameChanged(string name)
    {
        Name = name;
        playerNameMatched.SetActive(!IsVaildName(name));
    }

    public bool IsVaildName(string name)
    {
        // TODO : 비속어 체크
        return Regex.IsMatch(name, playerNameExpression);
    }
}

