using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerTwo : MonoBehaviour
{
    private bool isTeleported = false;
    public Camera cam;
    public NavMeshAgent agent;
    public float constantSpeed = 2f;

    void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = constantSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player can move
        if (!isTeleported)
        {
            agent.isStopped = false;

            // Moving the player to cursor location (right click)
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }

    public void SetTeleported(bool teleported)
    {
        isTeleported = teleported;
    }
}