using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

public class PagePlayerInfo : MonoBehaviour, IPage
{
    public static int Hash { get; private set; }
    public string PageName { get; } = "PlayerInfo";
    
    CharacterSelection characterSelect => GameManager.Instance.CharacterSelection;

    string playerNameExpression = @"^[가-힣a-zA-Z0-9]{2,10}$";
    // string exceptExpression = @"[^가-힣a-zA-Z0-9]";

    [Header("Character Info")]
    [SerializeField] string playerName = string.Empty;
    [SerializeField] CharacterType currentCharacterType = CharacterType.Penguin;

    [Header("UI")]
    [SerializeField] GameObject panel;
    [SerializeField] Image characterPreview;
    [SerializeField] Transform characterList;
    [Space(10f)]
    [SerializeField] TMP_InputField inputFieldPlayerName;
    [SerializeField] GameObject playerNameMatched;
    [Header("Prefab")]
    [SerializeField] Button prefCharacterCard;


    void Awake()
    {
        Hash = PageName.GetHashCode();
    }

    void Start()
    {
        if(!GameManager.Instance.pages.ContainsKey(Hash))
            GameManager.Instance.pages.Add(Hash, this);
            
        // 캐릭터 카드 만들어 주기
        foreach (CharacterData data in characterSelect.datas)
        {
            Button btn = Instantiate(prefCharacterCard, characterList);
            btn.transform.GetChild(0).GetComponent<Image>().sprite = data.sprite;
            btn.onClick.AddListener(()=>{ OnClickCharacterCard(data.type); });
        }
    }


    public void Open()
    {
        panel.SetActive(true);

        characterPreview.sprite = characterSelect.Map[currentCharacterType].sprite;

        inputFieldPlayerName.text = playerName;
    }

    public void Close()
    {
        panel.SetActive(false);
    }


    public void OnClickJoin()
    {
        if(!IsVaildPlayerName(playerName))
            return;

        GameManager.Instance.PlayerManager.UpdatePlayer(currentCharacterType, playerName);

        Close();
    }

    #region *** 플레이어 이름 입력 ***


    public void OnPlayerNameChanged(string name)
    {
        playerName = name;
        playerNameMatched.SetActive(!IsVaildPlayerName(name));
    }

    bool IsVaildPlayerName(string name)
    {
        return Regex.IsMatch(name, playerNameExpression);
    }

    #endregion
    
    
    // 기능이 더 커지면 분리하는 것도 고려
    #region *** 캐릭터 선택 *** 

    public void OpenCharacterList()
    {
        characterList.gameObject.SetActive(true);
    }

    public void OnClickCharacterCard(CharacterType type)
    {
        characterList.gameObject.SetActive(false);
        
        currentCharacterType = type;

        characterPreview.sprite = characterSelect.Map[type].sprite;
    }

    #endregion
    
}
