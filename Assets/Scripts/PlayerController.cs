using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private bool isTeleported = false;
    private Camera cam; // Change this to private

    public NavMeshAgent agent;
    public float constantSpeed = 2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = constantSpeed;

        // Register for the onPreCull event to dynamically update the cam variable
        Camera.onPreCull += UpdateCam;
    }

    void OnDestroy()
    {
        // Unregister the event when the script is destroyed to prevent memory leaks
        Camera.onPreCull -= UpdateCam;
    }

    private void UpdateCam(Camera activeCam)
    {
        cam = activeCam; // Update the cam variable with the currently active camera
    }

    void Update()
    {
        if (!isTeleported)
        {
            agent.isStopped = false;

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    agent.destination = hit.point;
                }
            }
        }
    }

    public void SetTeleported(bool teleported)
    {
        isTeleported = teleported;
    }
}














