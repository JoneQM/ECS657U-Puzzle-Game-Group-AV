using System.Collections;
using UnityEngine;
using Unity.AI.Navigation;
using System.Collections.Generic;

public class InteractableTile : MonoBehaviour
{
    public LayerMask playerLayer; // Set this in the inspector to the player's layer
    public List<SpikeTrap> associatedSpikeTraps; // Use a list to hold multiple traps
    public float trapActiveDelay = 5f; // Time in seconds for the traps to be active again
    private NavMeshSurface navMeshSurface; // Reference to the NavMeshSurface

    private void Start()
    {
        // Cache the NavMeshSurface component at start
        navMeshSurface = Object.FindFirstObjectByType<NavMeshSurface>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player using the layer mask
        if ((playerLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            Debug.Log("Player has interacted with the red tile.");
            ToggleTraps(false); // Deactivate traps
            StartCoroutine(ReactivateTrapsAfterDelay()); // Reactivate traps after delay
        }
    }

    private void ToggleTraps(bool state)
    {
        // Toggle the state of the traps
        foreach (var spikeTrap in associatedSpikeTraps)
        {
            if (spikeTrap != null)
            {
                spikeTrap.ToggleSpikes(state);
            }
        }
        // Update the NavMesh to reflect the new state of the traps
        if (navMeshSurface != null)
        {
            navMeshSurface.BuildNavMesh();
        }
    }

    private IEnumerator ReactivateTrapsAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(trapActiveDelay);
        ToggleTraps(true); // Reactivate traps
    }
}

