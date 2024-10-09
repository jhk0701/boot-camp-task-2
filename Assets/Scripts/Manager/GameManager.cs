using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(SceneManager))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public PlayerManager PlayerManager { get; private set;}
    public SceneManager SceneManager { get; private set; }

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;   
        }

        Instance =  this;

        PlayerManager = GetComponent<PlayerManager>();
        SceneManager = GetComponent<SceneManager>();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene(SceneManager.GAME_SCENE);
    }
}