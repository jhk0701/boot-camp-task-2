using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;

public class PlayerNameEditor : MonoBehaviour, IPopUpable
{
    public string Name {get; private set;}
    string playerNameExpression = @"^[가-힣a-zA-Z0-9]{2,10}$";

    [SerializeField] BadWordFilter badWordFilter;
    [Space(10f)]
    [SerializeField] Transform panel;
    [SerializeField] TMP_InputField inputFieldPlayerName;
    [SerializeField] GameObject playerNameMatched;
    [SerializeField] TMP_Text txtNameMatched;
    
    void Start()
    {
        if (badWordFilter.BadWords == null || badWordFilter.BadWords.Count == 0)
            badWordFilter.Initialize();
    }

    public void PopUp()
    {
        panel.gameObject.SetActive(true);
        
        if(MainManager.Instance.PlayerManager.Player == null)
            inputFieldPlayerName.text = Name = "";
        else
            inputFieldPlayerName.text = Name = MainManager.Instance.PlayerManager.Player.Name;
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
        IsVaildName(name);
    }

    public bool IsVaildName(string name)
    {
        // 1차 정규표현식 체크
        if(!CheckRegex(name))
            return false;

        // 2차 비속어 체크
        return CheckBadWord(name);
    }

    bool CheckRegex(string name)
    {
        bool result = Regex.IsMatch(name, playerNameExpression);

        playerNameMatched.SetActive(!result);
        if(!result)
            txtNameMatched.text = "입력한 이름이 조건에 일치하지 않습니다.";
        
        return result;
    }

    bool CheckBadWord(string name)
    {
        bool result = badWordFilter.IsVaild(name);

        playerNameMatched.SetActive(!result);
        if(!result)
            txtNameMatched.text = "입력한 이름에 비속어가 포함되어 있습니다.";

        return result;
    }
}