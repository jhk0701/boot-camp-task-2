using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    InputController controller;
    Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] float speed = 10f;

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
        
        anim.SetBool("IsMove", Convert.ToBoolean(val));

        rb.velocity = dir * speed * Time.deltaTime * 100f;
    }
}
