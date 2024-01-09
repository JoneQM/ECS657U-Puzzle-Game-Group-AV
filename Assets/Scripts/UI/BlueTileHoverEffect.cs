using UnityEngine;

public class BlueTileHoverEffect : MonoBehaviour
{
    public ParticleSystem tileParticleSystem;

    private void Start()
    {
        // Ensure that the particle system is not playing when the game starts.
        if (tileParticleSystem != null)
        {
            tileParticleSystem.Stop();
            tileParticleSystem.gameObject.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        // Enable and play the particle system when the mouse enters the collider of the blue tile.
        if (tileParticleSystem != null)
        {
            tileParticleSystem.gameObject.SetActive(true);
            tileParticleSystem.Play();
        }
    }

    private void OnMouseExit()
    {
        // Stop and disable the particle system when the mouse exits the collider.
        if (tileParticleSystem != null)
        {
            tileParticleSystem.Stop();
            tileParticleSystem.gameObject.SetActive(false);
        }
    }
}
