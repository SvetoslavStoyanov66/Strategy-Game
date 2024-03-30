using System.Data.Common;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    Camera myCam;
    NavMeshAgent myAgent;
    public LayerMask ground;
    Animator animator;
    bool isMoving = false;
    void Start()
    {
        UnitSelect.Instance.allUnits.Add(this.gameObject);
        myAgent = GetComponent<NavMeshAgent>();
        myCam = Camera.main;
        animator = GetComponent<Animator>();
    }
    void Destroy()
    {
        UnitSelect.Instance.allUnits.Remove(this.gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && UnitSelect.Instance.selectedUnits.Contains(this.gameObject))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                myAgent.SetDestination(hit.point);
                isMoving = true; // Set the flag to indicate movement
            }
        }

        // Check if the agent is moving and update the animator accordingly
        animator.SetBool("isRunning", isMoving);

        // Check if the agent has reached its destination
        if (isMoving && !myAgent.pathPending && myAgent.remainingDistance <= myAgent.stoppingDistance + 0.8f)
        {
            isMoving = false; // Set the flag to indicate that the unit has stopped moving
        }
    }
}
