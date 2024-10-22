using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(SceneLoader))]
[RequireComponent(typeof(CharacterSelection))]
public class MainManager : Singleton<MainManager>
{
    public PlayerManager PlayerManager { get; private set;}
    public SceneLoader SceneLoader { get; private set; }
    public CharacterSelection CharacterSelection { get; private set; }


    void Awake()
    {
        PlayerManager = GetComponent<PlayerManager>();
        SceneLoader = GetComponent<SceneLoader>();
        CharacterSelection = GetComponent<CharacterSelection>();
    }

}