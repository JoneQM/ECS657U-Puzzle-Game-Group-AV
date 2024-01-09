using System.Collections;
using UnityEngine;
using Unity.AI.Navigation;
using System.Collections.Generic;

public class InteractableTile : MonoBehaviour
{
    public LayerMask playerLayer; 
    public List<SpikeTrap> associatedSpikeTraps; 
    public float trapActiveDelay = 5f; 
    private NavMeshSurface navMeshSurface; 

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
            // Deactivate traps
            ToggleTraps(false); 
            // Reactivate traps after delay
            StartCoroutine(ReactivateTrapsAfterDelay()); 
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
        // Reactivate traps
        ToggleTraps(true); 
    }
}