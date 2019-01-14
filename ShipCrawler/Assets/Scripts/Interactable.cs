using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    [Header("Set Size of Boundaries")]
    public float sizeX = 1f;
    public float sizeY = 1f;
    public float sizeZ = 1f;
    public Transform interactionTransform;
    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;
    
    public virtual void Interact()
    {
        // This method is meant to be overwritten
    }

    void Update()
    {
        // If we are currently being focused
        // and we haven't already interacted with the object
        if (isFocus && !hasInteracted)
        {
            // If we are close enough
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                // Interact with the object
                Interact();
                hasInteracted = true;
            }
        }
    }

    // Called when the object starts being focused
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    // Called when the object is no longer focused
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        //Piirretään rajat millä osutaan objektiin

        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
       
        Gizmos.DrawCube(interactionTransform.position, new Vector3(sizeX, sizeY, sizeZ));
    }
}
