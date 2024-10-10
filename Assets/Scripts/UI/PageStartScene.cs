using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerNameEditor))]
[RequireComponent(typeof(PlayerCharacterSelector))]
public class PageStartScene : MonoBehaviour, IPage
{
    public static int Hash { get; private set; }
    public string PageName { get; } = "StartScene";
    
    PlayerNameEditor PlayerName;
    PlayerCharacterSelector PlayerCharacter;

    [Header("UI")]
    [SerializeField] GameObject panel;
    [SerializeField] Image characterPreview;


    void Awake()
    {
        Hash = PageName.GetHashCode();
        
        PlayerName = GetComponent<PlayerNameEditor>();
        PlayerCharacter = GetComponent<PlayerCharacterSelector>();
    }

    void Start()
    {
        StartManager.Instance.pages.Add(Hash, this);

        PlayerCharacter.onCharacterChanged += (CharacterType type) => 
        {
            characterPreview.sprite = MainManager.Instance.CharacterSelection.Map[type].sprite;
        };
    }

    public void Open()
    {
        panel.SetActive(true);

        characterPreview.sprite = MainManager.Instance.CharacterSelection.Map[PlayerCharacter.CurrentCharacterType].sprite;

        PlayerName.PopUp();
    }

    public void Close()
    {
        panel.SetActive(false);
    }

    public void OnClickJoin()
    {
        if (!PlayerName.IsVaildName(PlayerName.Name))
            return;

        MainManager.Instance.SceneLoader.Load(SceneLoader.SCENE_GAME, 
            () => 
            {
                MainManager.Instance.PlayerManager.Initialize(); 
                MainManager.Instance.PlayerManager.UpdatePlayerName(PlayerName.Name);
                MainManager.Instance.PlayerManager.UpdatePlayerCharacter(PlayerCharacter.CurrentCharacterType);
            }
        );

        Close();
    }
}
