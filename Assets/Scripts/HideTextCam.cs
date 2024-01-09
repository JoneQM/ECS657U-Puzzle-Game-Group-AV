using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTextWhenMainCamera : MonoBehaviour
{
    public Camera mainCamera;
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        // Start with the text hidden
        textMeshPro.enabled = false; 
    }

    private void Update()
    {
        if (mainCamera != null)
        {
            if (Camera.main == mainCamera)
            {
                // Enable the text when the main camera is active
                textMeshPro.enabled = true; 
            }
            else
            {
                // Disable the text for other cameras
                textMeshPro.enabled = false; 
            }
        }
    }
}
