using UnityEngine;
using UnityEngine.AI;
using TMPro; 

public class Teleporter : MonoBehaviour
{
    public LayerMask playerLayers;
    public Transform teleportTo;
    public TextMeshProUGUI teleportPrompt; 

    private bool awaitingTeleportConfirmation = false;
    private NavMeshAgent agentToTeleport;

    private void OnTriggerEnter(Collider collision)
    {
        // Check if the colliding object is on one of the player layers
        if ((playerLayers & (1 << collision.gameObject.layer)) != 0)
        {
            Debug.Log(collision.name + " entered teleporter. Awaiting confirmation.");

            // Store agent and enable confirmation prompt
            agentToTeleport = collision.GetComponent<NavMeshAgent>();
            awaitingTeleportConfirmation = true;
            teleportPrompt.enabled = true; // Show prompt
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        // Check for confirmation input while player is still within the trigger
        if (awaitingTeleportConfirmation && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Teleport confirmed!");
            TeleportPlayer();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        // Cancel teleportation if player exits without confirming
        if (awaitingTeleportConfirmation)
        {
            Debug.Log("Player exited teleporter without confirming.");
            CancelTeleport();
        }
    }

    private void Update()
    {
        // Optionally handle input in Update if OnTriggerStay isn't suitable
        if (awaitingTeleportConfirmation && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Teleport confirmed!");
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        if (agentToTeleport != null)
        {
            agentToTeleport.Warp(teleportTo.position);

            // Call the method to set isTeleported to true on the player's controller script
            PlayerController playerController = agentToTeleport.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.SetTeleported(true);
                // Allows the player to move again after being teleported
                playerController.SetTeleported(false);
            }
        }
        awaitingTeleportConfirmation = false;
        teleportPrompt.enabled = false; 
        agentToTeleport = null;
    }

    private void CancelTeleport()
    {
        awaitingTeleportConfirmation = false;
        teleportPrompt.enabled = false; 
        agentToTeleport = null;
    }
}






