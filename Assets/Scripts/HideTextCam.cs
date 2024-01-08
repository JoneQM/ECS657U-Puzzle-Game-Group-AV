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
        textMeshPro.enabled = false; // Start with the text hidden
    }

    private void Update()
    {
        if (mainCamera != null)
        {
            if (Camera.main == mainCamera)
            {
                textMeshPro.enabled = true; // Enable the text when the main camera is active
            }
            else
            {
                textMeshPro.enabled = false; // Disable the text for other cameras
            }
        }
    }
}
