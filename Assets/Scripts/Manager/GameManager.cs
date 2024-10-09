using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(SceneLoader))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public PlayerManager PlayerManager { get; private set;}
    public SceneLoader SceneLoader { get; private set; }
    public CharacterSelection CharacterSelection {get; private set; }
    
    // 각 세부 기능에 대한 맵
    // 이름 - 해당 맵
    public Dictionary<int, IPage> pages = new Dictionary<int, IPage>();


    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;   
        }

        Instance =  this;

        PlayerManager = GetComponent<PlayerManager>();
        SceneLoader = GetComponent<SceneLoader>();
        CharacterSelection = GetComponent<CharacterSelection>();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneLoader.Load(SceneLoader.GAME_SCENE, 
            () => 
            { 
                // 플레이어 초기화
                PlayerManager.Initialize(); 

                // 캐릭터 생성 페이지 열기
                pages[PagePlayerInfo.Hash].Open();
            }
        );
    }
}