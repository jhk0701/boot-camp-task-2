using UnityEngine;

public class NpcInteraction : InteractableObject
{
    SpriteRenderer characterRenderer;

    void Awake()
    {
        characterRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    
    void Update()
    {
        if (HasNearbyPlayer)
        {
            Vector2 dir = (NearbyPlayer.transform.position - transform.position).normalized;
            float r = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            characterRenderer.flipX = Mathf.Abs(r) > 90;
        }
    }
}