using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private readonly int isMove = Animator.StringToHash("isMove");

    private InputController controller;
    private Rigidbody2D rb;

    [SerializeField] private Animator anim;
    [SerializeField] private float speed = 30f;


    void Awake()
    {
        controller = GetComponent<InputController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        controller.OnMoveEvent += Move;
    }
    
    
    void Move(Vector2 dir)
    {
        int val = (int)dir.magnitude;

        anim.SetBool(isMove, val == 1);

        rb.velocity = dir * speed * Time.deltaTime * 100f;
    }
}
