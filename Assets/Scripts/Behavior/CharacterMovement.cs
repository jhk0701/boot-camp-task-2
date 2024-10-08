using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private InputController controller;
    private Rigidbody2D rb;
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
        rb.velocity = dir * speed * Time.deltaTime * 100f;
    }
}
