using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGatheringAI : MonoBehaviour
{
    private Unit unit;
    private GameObject currentResource;
    private GameObject storageArea;
    private bool isGathering = false;
    private int stoneAmountInUnit;
    void Start()
    {
        unit = GetComponent<Unit>();
        storageArea = GameObject.FindGameObjectWithTag("StorageArea");
    }
    public void GatheringResource(GameObject resource)
    {
        currentResource = resource;
        MoveToResource(resource.transform.position);
        isGathering = true;
    }
    public void MoveToResource(Vector3 position)
    {
        unit.MoveTo(position);
    }
    public void MoveToStorage()
    {
        unit.MoveTo(storageArea.transform.position);
    }
    public void CancelGathering()
    {
        isGathering = false;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(isGathering)
        {
            if(other.gameObject == currentResource)
            {
                {
                    unit.StopMovement();
                    StartCoroutine(DiggingRoutine());
                }
            }
            else if(other.gameObject == storageArea)
            {
                unit.StopMovement();
                GatheringResource(currentResource);
                RecourseTracker.Instance.StoneValueChaning(stoneAmountInUnit);
                stoneAmountInUnit = 0;
            }
        }

    }
    IEnumerator DiggingOnce()
    {
        yield return new WaitForSeconds(1);
        stoneAmountInUnit++;
    }
    IEnumerator DiggingRoutine()
    {
        for (int i = 1; i <= 3; i++)
        {
            if (isGathering)
            {
                unit.StopMovement();
                yield return StartCoroutine(DiggingOnce());
            }
            else
            {
                isGathering = false;
                break;
            }
        }
        MoveToStorage();
    }
}
