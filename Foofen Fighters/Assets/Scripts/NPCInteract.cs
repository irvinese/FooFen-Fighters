using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    public Dialogue dialogue;
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            stopEverything();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    public void TryInteract()
    {
        if (playerInRange)
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (dialogue != null)
        {
            dialogue.StartDialogue();
        } 
    }

    public void stopEverything(){
        if (dialogue != null)
        {
            dialogue.StopDialogue(); // Stop the dialogue
        }
       
    }
}
    

