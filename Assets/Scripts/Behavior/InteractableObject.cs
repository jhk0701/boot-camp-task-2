using System;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{    
    public Player NearbyPlayer { get; protected set;}
    public bool HasNearbyPlayer { get { return NearbyPlayer != null;}}

    [SerializeField] protected GameObject panelInteractionGuide;

    public event Action Interact;
    public event Action OnEndInteract;

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag.Equals("Player"))
        {
            panelInteractionGuide.SetActive(true);

            NearbyPlayer = collider.gameObject.GetComponent<Player>();
            NearbyPlayer.GetComponent<InputController>().SetInteract(Interact);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            panelInteractionGuide.SetActive(false);

            NearbyPlayer.GetComponent<InputController>().ClearInteract();
            NearbyPlayer = null;

            OnEndInteract?.Invoke();
        }
    }
}
