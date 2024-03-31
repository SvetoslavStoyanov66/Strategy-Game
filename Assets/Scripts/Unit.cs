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
    UnitGatheringAI unitGatheringAI;
    void Start()
    {
        UnitSelect.Instance.allUnits.Add(this.gameObject);
        myAgent = GetComponent<NavMeshAgent>();
        myCam = Camera.main;
        animator = GetComponent<Animator>();
        unitGatheringAI = GetComponent<UnitGatheringAI>();
    
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
            // Check if the hit object is a resource
            ResourceNode resourceNode = hit.collider.GetComponent<ResourceNode>();
            if (resourceNode != null)
            {
                // Move to gather resource
                unitGatheringAI.GatheringResource(resourceNode.gameObject);
            }
            else
            {
                // Check if the hit object is the storage area
                if (hit.collider.CompareTag("StorageArea"))
                {
                    unitGatheringAI.MoveToStorage();
                }
                else
                {
                    // Move to the clicked point
                    unitGatheringAI.CancelGathering();
                    myAgent.SetDestination(hit.point);
                    isMoving = true;
                }
            }
            }
        }

        animator.SetBool("isRunning", isMoving);

        if (isMoving && !myAgent.pathPending && myAgent.remainingDistance <= myAgent.stoppingDistance + 0.8f)
        {
            isMoving = false; 
        }
    }
    public void MoveTo(Vector3 position)
    {
        myAgent.SetDestination(position);
        isMoving = true;
    }
    public void StopMovement()
    {
        myAgent.ResetPath();
    }
}