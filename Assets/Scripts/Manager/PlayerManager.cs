using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject prefPlayer;

    public Transform Player { get; private set; }
    public GameObject PlayerCharacter { get; private set; }
    public string PlayerName {get; private set; }

    [Header("Player UI")]
    [SerializeField] Transform playerCanvas;
    [SerializeField] TextMeshProUGUI txtPlayerName;

    public void Initialize()
    {
        Player = Instantiate(prefPlayer).transform;
        
        Camera.main.transform.SetParent(Player);
        playerCanvas.SetParent(Player);
    }

    public void UpdatePlayerName(string newName)
    {
        txtPlayerName.text = PlayerName = newName;
        // 변경
    }

    public void UpdatePlayerCharacter(CharacterType type)
    {
        if (PlayerCharacter != null)
            Destroy(PlayerCharacter);

        PlayerCharacter = MainManager.Instance.CharacterSelection.CreateCharacter(type, Player);
        
        AnimationController animCtrl = Player.GetComponent<AnimationController>();
        animCtrl.AssignAnimator(PlayerCharacter.GetComponent<Animator>());
    }
}