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
    Animator animator;

    GameObject picaxe; 
    void Start()
    {
        unit = GetComponent<Unit>();
        storageArea = GameObject.FindGameObjectWithTag("StorageArea");
        animator = GetComponent<Animator>();
        picaxe = transform.GetChild(1).GetChild(5).GetChild(0).GetChild(0).GetChild(7).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject;
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
        animator.SetBool("isMining",true);
        yield return new WaitForSeconds(1);
        stoneAmountInUnit++;
        animator.SetBool("isMining",false);
    }
    IEnumerator DiggingRoutine()
    {
        picaxe.SetActive(true);
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

        picaxe.SetActive(false);
        MoveToStorage();
    }
}
