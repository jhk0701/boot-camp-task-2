using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    // TODO 무조건 하나의 이벤트만 갖는 제약 조건
    event Action OnInteractEvent;
    

    public void SetInteract(Action interact)
    {
        OnInteractEvent = interact;
    }

    public void ClearInteract()
    {
        OnInteractEvent = null;
    }


    public void CallMoveEvent(Vector2 dir)
    {
        OnMoveEvent?.Invoke(dir);
    }

    public void CallLookEvent(Vector2 dir)
    {
        OnLookEvent?.Invoke(dir);
    }

    public void CallInteractEvent()
    {
        OnInteractEvent?.Invoke();
    }
}
