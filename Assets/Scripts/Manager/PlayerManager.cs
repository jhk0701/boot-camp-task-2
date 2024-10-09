using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterType 
{
    Penguin,
}

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject prefPlayer;
    public Transform Player { get; private set; }
    GameObject currentRenderer;
    
    [Header("Character Info")]
    // TODO : 캐릭터 관련 정보 분리하기
    public CharacterType currentCharacterType;
    public GameObject[] characters;

    [Header("Player Info")]
    [SerializeField] Transform playerCanvas;
    [SerializeField] TextMeshProUGUI txtPlayerName;
    string playerName;

    // TODO : 입력만 받는 클래스로 책임 분리
    [Header("Player Name Input")]
    [SerializeField] GameObject panelPlayerName;

    void Start()
    {
        OpenPlayerNameInput();

        Player = Instantiate(prefPlayer).transform;

        CreatePlayerCharacter();
        
        Camera.main.transform.SetParent(Player);
        playerCanvas.SetParent(Player);
    }

    public void CreatePlayerCharacter(CharacterType type = CharacterType.Penguin)
    {
        currentCharacterType = type;
        currentRenderer = Instantiate(characters[(int)type], Player.transform);

        AnimationController pAnim = Player.GetComponent<AnimationController>();
        pAnim.AssignAnimator(currentRenderer.GetComponent<Animator>());
    }


    public void OpenPlayerNameInput()
    {
        panelPlayerName.SetActive(true);
    }

    public void OnValueChangedPlayerName(string name)
    {
        // TODO : 정규식 적용
        playerName = name;
    }

    public void CheckPlayerName()
    {
        if(playerName.Length == 0)
            return;

        panelPlayerName.SetActive(false);

        txtPlayerName.text = playerName;
    }
}