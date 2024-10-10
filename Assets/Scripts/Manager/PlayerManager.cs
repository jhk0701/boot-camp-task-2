using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject prefPlayer;
    public Transform Player { get; private set; }
    public GameObject PlayerCharacter { get; private set; }

    string playerName;

    [Header("Player UI")]
    [SerializeField] Transform playerCanvas;
    [SerializeField] TextMeshProUGUI txtPlayerName;

    public void Initialize()
    {
        Player = Instantiate(prefPlayer).transform;
        
        Camera.main.transform.SetParent(Player);
        playerCanvas.SetParent(Player);
    }

    public void UpdatePlayer(CharacterType type, string newName = "")
    {
        if(newName.Length > 0)
            txtPlayerName.text = playerName = newName;

        if (PlayerCharacter != null)
            Destroy(PlayerCharacter);

        PlayerCharacter = GameManager.Instance.CharacterSelection.CreateCharacter(type, Player);
        
        AnimationController animCtrl = Player.GetComponent<AnimationController>();
        animCtrl.AssignAnimator(PlayerCharacter.GetComponent<Animator>());
    }
}