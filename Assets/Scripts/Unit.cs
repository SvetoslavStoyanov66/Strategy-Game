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
    void OnDestroy()
    {
        UnitSelect.Instance.allUnits.Remove(this.gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && UnitSelect.Instance.selectedUnits.Contains(gameObject))
        {
            MoveToRaycastHit(RayCastManager.Instance.hitInfo.point);
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
      void MoveToRaycastHit(Vector3 hitPoint)
    {
        // Check if the hit object is a resource
        ResourceNode resourceNode = RayCastManager.Instance.hitInfo.collider.GetComponent<ResourceNode>();
        if (resourceNode != null)
        {
            // Move to gather resource
            unitGatheringAI.GatheringResource(resourceNode.gameObject);
        }
        else
        {
            // Move to the hit point obtained from the RayCastManager
            unitGatheringAI.CancelGathering();
            myAgent.SetDestination(hitPoint);
            isMoving = true;
        }
    }
}