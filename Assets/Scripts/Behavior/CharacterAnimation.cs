using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private readonly int isMove = Animator.StringToHash("isMove");

    private InputController controller;

    [SerializeField] private Animator anim;
    // private Player player;


    void Awake()
    {
        controller = GetComponent<InputController>();
        
        controller.OnMoveEvent += Move;
        
        // 추가적인 사용이 있을 것이라면 필드로 분리할 것
        GetComponent<Player>().OnCharacterChangedEvent += ChangeAnimator;
    }
    
    void Move(Vector2 dir)
    {
        if(anim == null) return;

        int val = (int)dir.magnitude;
        anim.SetBool(isMove, val == 1);
    }

    void ChangeAnimator(GameObject newChar)
    {
        anim = newChar.GetComponent<Animator>();
    }
}