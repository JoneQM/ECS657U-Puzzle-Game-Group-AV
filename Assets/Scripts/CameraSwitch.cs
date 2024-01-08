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

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("PlayerOne") || other.CompareTag("PlayerTwo")) // Replace with the tags of your player GameObjects
    //     {
    //         Debug.Log("Player entered trigger zone.");

    //         // Disable the current camera component
    //         cameras[currentCameraIndex].enabled = false;

    //         // Cycle to the next camera in the array
    //         currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

    //         // Enable the new current camera component
    //         cameras[currentCameraIndex].enabled = true;
    //     }
    // }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerOne") || other.CompareTag("PlayerTwo"))
        {
            Debug.Log("Player entered trigger zone.");

            // Check the current active camera and switch accordingly
            if (currentCameraIndex == 0) // If main camera is active
            {
                // Switch to the second camera
                cameras[currentCameraIndex].enabled = false;
                currentCameraIndex = 1;
                cameras[currentCameraIndex].enabled = true;
            }
            else if (currentCameraIndex == 1) // If second camera is active
            {
                // Switch back to the main camera
                cameras[currentCameraIndex].enabled = false;
                currentCameraIndex = 0;
                cameras[currentCameraIndex].enabled = true;
            }
            // If currentCameraIndex is 2 or any other number, no action is taken
        }
    }


}
