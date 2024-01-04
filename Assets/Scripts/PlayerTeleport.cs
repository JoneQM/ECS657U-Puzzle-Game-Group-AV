using UnityEngine;
using UnityEngine.AI;

public class Teleporter : MonoBehaviour
{
    public LayerMask playerLayers;
    public Transform teleportTo;



    private void OnTriggerEnter(Collider collision)
    {
        // Check if the colliding object is on one of the player layers
        if ((playerLayers & (1 << collision.gameObject.layer)) != 0)
        {
            Debug.Log("TELEPORTING " + collision.name);

            // Warp the player to the new position
            NavMeshAgent agent = collision.GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                agent.Warp(teleportTo.position);
            }

            // Call the method to set isTeleported to true on the player's controller script
            if (collision.CompareTag("PlayerOne"))
            {
                PlayerController playerController = collision.GetComponent<PlayerController>();
                if (playerController != null)
                {
                    playerController.SetTeleported(true);
                    Debug.Log("Teleport has been completed for PlayerOne");
                    playerController.SetTeleported(false);
                }
            }
            else if (collision.CompareTag("PlayerTwo"))
            {
                PlayerControllerTwo playerController = collision.GetComponent<PlayerControllerTwo>();
                if (playerController != null)
                {
                    playerController.SetTeleported(true);
                    Debug.Log("Teleport has been completed for PlayerTwo");
                    playerController.SetTeleported(false);
                }
            }
        }
    }
}





