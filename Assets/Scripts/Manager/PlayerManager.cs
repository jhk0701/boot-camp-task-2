using System.Collections.Generic;
using UnityEngine;

public enum CharacterType 
{
    Penguin,
}

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject prefPlayer;
    public Transform Player { get; private set; }
    GameObject currentRenderer;
    
    // TODO : 캐릭터 관련 정보 분리하기
    // 추후 변경 가능하도록
    public CharacterType currentCharacterType;
    public List<GameObject> characters;

    void Start()
    {
        Player = Instantiate(prefPlayer).transform;

        CreatePlayerCharacter();
        
        Camera.main.transform.SetParent(Player);
    }

    public void CreatePlayerCharacter(CharacterType type = CharacterType.Penguin)
    {
        currentCharacterType = type;
        currentRenderer = Instantiate(characters[(int)type], Player.transform);

        AnimationController pAnim = Player.GetComponent<AnimationController>();
        pAnim.AssignAnimator(currentRenderer.GetComponent<Animator>());
    }
}