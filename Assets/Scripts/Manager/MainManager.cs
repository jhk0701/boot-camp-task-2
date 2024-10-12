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
    public CharacterSelection CharacterSelection { get; private set; }


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