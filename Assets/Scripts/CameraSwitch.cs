using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera extendedMapCamera;
    public Camera thirdCamera;

    private Camera[] cameras;
    private int currentCameraIndex = 0;

    private void Start()
    {
        // Create an array of camera components
        cameras = new Camera[] { mainCamera, extendedMapCamera, thirdCamera };

        // Ensure only the first camera is enabled initially
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].enabled = false;
        }

        // Ensure the first camera is enabled
        cameras[0].enabled = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerOne") || other.CompareTag("PlayerTwo"))
        {
            Debug.Log("Player entered trigger zone.");

            // Check the current active camera and switch accordingly
            if (currentCameraIndex == 0) 
            {
                // Switch to the second camera
                cameras[currentCameraIndex].enabled = false;
                currentCameraIndex = 1;
                cameras[currentCameraIndex].enabled = true;
            }
            else if (currentCameraIndex == 1) 
            {
                // Switch back to the main camera
                cameras[currentCameraIndex].enabled = false;
                currentCameraIndex = 0;
                cameras[currentCameraIndex].enabled = true;
            }
            
        }
    }


}
