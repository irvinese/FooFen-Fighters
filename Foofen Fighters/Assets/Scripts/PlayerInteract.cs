using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private NPCInteract currentInteractable; // Track the currently interacting NPC

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentInteractable != null)
            {
                currentInteractable.TryInteract();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        NPCInteract npcInteractable = other.GetComponent<NPCInteract>();
        if (npcInteractable != null)
        {
            currentInteractable = npcInteractable; // Set the current interactable NPC
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        NPCInteract npcInteractable = other.GetComponent<NPCInteract>();
        if (npcInteractable == currentInteractable)
        {
            currentInteractable = null; // Reset the current interactable NPC
        }
    }
}
