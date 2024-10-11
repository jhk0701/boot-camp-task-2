using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : InputController
{
    [SerializeField] bool isInteracting = false;

    public void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>().normalized;
        
        CallMoveEvent(dir);
    }

    public void OnLook(InputValue value)
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
        Vector2 aim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(aim);
    }

    public void OnInteract(InputValue value)
    {
        if(IsInvoking("SetInteractable")) return;

        isInteracting = value.isPressed;
        Invoke("SetInteractable", 1f);

        CallInteractEvent();
    }

    void SetInteractable()
    {
        isInteracting = false;
    }
}