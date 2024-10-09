using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PagePlayerInfo : MonoBehaviour, IPage
{
    public static int Hash { get; private set; }
    public string PageName { get; } = "PlayerInfo";
    
    CharacterSelection characterSelect => GameManager.Instance.CharacterSelection;
    
    [Header("Character Info")]
    [SerializeField] string playerName;
    [SerializeField] CharacterType currentCharacterType = CharacterType.Penguin;

    [Header("UI")]
    [SerializeField] GameObject panel;
    [SerializeField] Image characterPreview;
    [SerializeField] Transform characterList;

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
    }

    public void Close()
    {
        panel.SetActive(false);
    }


    public void OnClickJoin()
    {
        GameManager.Instance.PlayerManager.UpdatePlayer(playerName, currentCharacterType);

        Close();
    }

    #region *** 플레이어 이름 입력 ***
    
    public void OnPlayerNameChanged(string name)
    {
        // TODO : 정규표현식 적용
        playerName = name;
    }

    bool IsVaildPlayerName()
    {
        return false;
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
