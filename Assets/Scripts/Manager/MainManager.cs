using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(SceneLoader))]
[RequireComponent(typeof(CharacterSelection))]
public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

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

        DontDestroyOnLoad(gameObject);
    }

}