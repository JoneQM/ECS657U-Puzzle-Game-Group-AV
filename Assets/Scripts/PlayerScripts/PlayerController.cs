using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private bool isTeleported = false;
    private Camera cam; 
    private GameManager gameManager;

    public NavMeshAgent agent;
    public float constantSpeed = 2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = constantSpeed;

        // Register for the onPreCull event to dynamically update the cam variable
        Camera.onPreCull += UpdateCam;

        // Find the GameManager in the scene
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

    void OnDestroy()
    {
        
        Camera.onPreCull -= UpdateCam;
    }

    private void UpdateCam(Camera activeCam)
    {
        cam = activeCam; 
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTwo"))
        {
            Debug.Log("Player 1 collided with Player 2"); 
            // Handle collision with Player 2 (e.g., game over)
            if (gameManager != null)
            {
                gameManager.PlayerCollision();
                gameObject.SetActive(false);
            }
        }
    }
}














