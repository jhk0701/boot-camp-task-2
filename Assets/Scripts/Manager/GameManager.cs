using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }

    public PlayerManager PlayerManager {get; private set;}

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;   
        }

        Instance =  this;

        PlayerManager = GetComponent<PlayerManager>();
    }

    void Start()
    {
        
    }
}