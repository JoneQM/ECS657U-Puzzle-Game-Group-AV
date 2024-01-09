using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public static event System.Action OnStarCollected;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "PlayerOne" or "PlayerTwo" tag
        if (other.CompareTag("PlayerOne") || other.CompareTag("PlayerTwo"))
        {
            // Notify that a star has been collected
            OnStarCollected?.Invoke();

            // Deactivate the star so it can't be collected again
            gameObject.SetActive(false);
        }
    }
}
