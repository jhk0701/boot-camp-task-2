using Unity.Mathematics;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private InputController controller;
    private Rigidbody2D rb;

    private Player player;
    private SpriteRenderer characterSprite;


    void Awake()
    {
        controller = GetComponent<InputController>();
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();

        controller.OnMoveEvent += Move;
        controller.OnLookEvent += Look;
        player.onCharacterChanged += ChangeCharacter;
    }


    void Move(Vector2 dir)
    {
        rb.velocity = dir * player.speed * Time.deltaTime * 100f;
    }

    void Look(Vector2 dir)
    {
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
        characterSprite.flipX = Mathf.Abs(rot) > 90;
    }

    void ChangeCharacter(GameObject newChar)
    {
        characterSprite = newChar.GetComponentInChildren<SpriteRenderer>();
    }
}
