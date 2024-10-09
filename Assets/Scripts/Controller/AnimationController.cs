using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private readonly int isMove = Animator.StringToHash("isMove");

    private InputController controller;

    [SerializeField] private Animator anim;


    void Awake()
    {
        controller = GetComponent<InputController>();
    }

    void Start()
    {
        controller.OnMoveEvent += Move;
    }
    
    
    void Move(Vector2 dir)
    {
        if(anim == null) return;

        int val = (int)dir.magnitude;
        anim.SetBool(isMove, val == 1);
    }

    public void AssignAnimator(Animator newAnimator)
    {
        anim = newAnimator;
    }
}