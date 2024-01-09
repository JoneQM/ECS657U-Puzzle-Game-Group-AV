using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private Collider spikeCollider;
    private Renderer spikeRenderer;

    void Start()
    {
        // Get the Collider and Renderer components from the spikes
        spikeCollider = GetComponent<Collider>();
        spikeRenderer = GetComponent<Renderer>();
    }

    public void ToggleSpikes(bool state)
    {
        // Enable or disable the collider and change the visual representation accordingly
        spikeCollider.enabled = state;
        spikeRenderer.enabled = state; 
    }
}
