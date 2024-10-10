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
        StartManager.Instance.pages.Add(Hash, this);

        PlayerName = GetComponent<PlayerNameEditor>();
        PlayerCharacter = GetComponent<PlayerCharacterSelector>();
    }

    public void Open()
    {
        panel.SetActive(true);

        characterPreview.sprite = MainManager.Instance.CharacterSelection.Map[PlayerCharacter.CurrentCharacterType].sprite;
    }

    public void Close()
    {
        panel.SetActive(false);
    }

    public void OnClickJoin()
    {
        if(!PlayerName.IsVaildPlayerName(PlayerName.Name))
            return;

        MainManager.Instance.SceneLoader.Load(SceneLoader.SCENE_GAME, 
            () => 
            {
                MainManager.Instance.PlayerManager.Initialize(); 
                MainManager.Instance.PlayerManager.UpdatePlayer(PlayerCharacter.CurrentCharacterType, PlayerName.Name);
            }
        );

        Close();
    }

}
