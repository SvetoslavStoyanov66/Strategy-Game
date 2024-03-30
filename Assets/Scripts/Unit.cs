using System.Data.Common;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    Camera myCam;
    NavMeshAgent myAgent;
    public LayerMask ground;
    void Start()
    {
        UnitSelect.Instance.allUnits.Add(this.gameObject);
        myAgent = GetComponent<NavMeshAgent>();
        myCam = Camera.main;
    }
    void Destroy()
    {
        UnitSelect.Instance.allUnits.Remove(this.gameObject);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1) && UnitSelect.Instance.selectedUnits.Contains(this.gameObject))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                myAgent.SetDestination(hit.point);
            }

        }
        
    }
}
