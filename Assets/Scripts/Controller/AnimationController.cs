using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private readonly int isMove = Animator.StringToHash("isMove");

    private InputController controller;
    // private Player player;

    [SerializeField] private Animator anim;


    void Awake()
    {
        controller = GetComponent<InputController>();
        
        controller.OnMoveEvent += Move;
        
        // 추가적인 사용이 있을 것이라면 필드로 분리할 것
        GetComponent<Player>().onCharacterChanged += ChangeAnimator;
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