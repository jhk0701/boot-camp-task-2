using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : InputController
{
    public void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>().normalized;
        CallMoveEvent(dir);
    }

    public void OnLook(InputValue value)
    {
        
    }
}