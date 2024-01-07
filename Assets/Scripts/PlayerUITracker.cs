using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class PlayerUITracker : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset; 
    public Camera mainCamera; 

    private RectTransform uiTransform; 
    
    public TMP_Text label; 

    void Start()
    {
        // Cache the RectTransform and Camera
        uiTransform = GetComponent<RectTransform>();
        // Automatically finds the main camera
        mainCamera = Camera.main; 
    }

    void Update()
    {
        // Check if the player and camera are assigned
        if(player != null && mainCamera != null)
        {
            // Convert the player's world position to screen space
            Vector3 screenPoint = mainCamera.WorldToScreenPoint(player.position + offset);

            // Update the position of the UI element
            uiTransform.position = screenPoint;

        }
    }
}


