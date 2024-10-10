using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public const int MAX_PLAYER_COUNT = 16;

    [SerializeField] Player prefPlayer;
    
    public Player Player { get; private set; }
    public List<Player> players = new List<Player>();

    public void Initialize()
    {
        Player = Instantiate(prefPlayer);
        
        Camera.main.transform.SetParent(Player.transform);
    }
    
}