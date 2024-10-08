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
    
    // TODO : ĳ���� ���� ���� �и��ϱ�
    // ���� ���� �����ϵ���
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