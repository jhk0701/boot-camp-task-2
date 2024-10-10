using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;

public class PlayerNameEditor : MonoBehaviour, IPopUpable
{
    public string Name {get; private set;}
    string playerNameExpression = @"^[가-힣a-zA-Z0-9]{2,10}$";

    [SerializeField] TMP_InputField inputFieldPlayerName;
    [SerializeField] GameObject playerNameMatched;
    
    void OnEnable()
    {
        inputFieldPlayerName.text = Name;
    }

    public void PopUp()
    {

    }

    public void OnPlayerNameChanged(string name)
    {
        Name = name;
        playerNameMatched.SetActive(!IsVaildPlayerName(name));
    }

    public bool IsVaildPlayerName(string name)
    {
        // TODO : 비속어 체크
        return Regex.IsMatch(name, playerNameExpression);
    }
}

