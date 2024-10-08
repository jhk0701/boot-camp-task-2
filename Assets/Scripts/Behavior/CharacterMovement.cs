using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private readonly int isMove = Animator.StringToHash("isMove");

    private InputController controller;
    private Rigidbody2D rb;

    [SerializeField] private Animator anim;
    [SerializeField] private float speed = 10f;

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
        int val = (int)(dir - Vector2.zero).magnitude;
        
        anim.SetBool(isMove, Convert.ToBoolean(val));

        rb.velocity = dir * speed * Time.deltaTime * 100f;
    }
}
