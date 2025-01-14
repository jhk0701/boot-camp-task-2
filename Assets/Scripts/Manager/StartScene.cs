using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerNameEditor))]
[RequireComponent(typeof(PlayerCharacterSelector))]
public class StartScene : MonoBehaviour
{
    PlayerNameEditor PlayerName;
    PlayerCharacterSelector PlayerCharacter;

    [Header("UI")]
    [SerializeField] GameObject panel;
    [SerializeField] Image characterPreview;


    void Awake()
    {
        PlayerName = GetComponent<PlayerNameEditor>();
        PlayerCharacter = GetComponent<PlayerCharacterSelector>();
    }

    void Start()
    {
        PlayerCharacter.onCharacterChanged += (CharacterType type) => 
        {
            characterPreview.sprite = MainManager.Instance.CharacterSelection.Map[type].sprite;
        };

        Open();
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
                
                MainManager.Instance.PlayerManager.Player.UpdateName(PlayerName.Name);
                MainManager.Instance.PlayerManager.Player.UpdateCharacter(PlayerCharacter.CurrentCharacterType);
            }
        );

        Close();
    }
}
