using UnityEngine;

public class InteractableObject : MonoBehaviour
{    
    public bool HasNearbyPlayer { get { return nearPlayer != null;}}
    [SerializeField] protected Player nearPlayer;
    [SerializeField] protected GameObject panelInteractionGuide;

    protected virtual void Interact()
    {
        Debug.Log("Interact!");
    }
    
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag.Equals("Player"))
        {
            panelInteractionGuide.SetActive(true);
            
            nearPlayer = collider.gameObject.GetComponent<Player>();
            nearPlayer.GetComponent<InputController>().SetInteract(Interact);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            panelInteractionGuide.SetActive(false);

            nearPlayer.GetComponent<InputController>().ClearInteract();
            nearPlayer = null;
        }
    }
}
