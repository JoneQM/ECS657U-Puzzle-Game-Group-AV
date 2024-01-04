using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
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
    
    void Update() {

        if (!isTeleported)
        {
            agent.isStopped = false;
        

            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
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







