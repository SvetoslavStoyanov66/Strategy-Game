﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsFunction : MonoBehaviour
{
    Camera myCam;
    [SerializeField]
    LayerMask buildings;
    GameObject currentSelection;
    private void Start()
    {
        myCam = Camera.main; 
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit hit = RayCastManager.Instance.hitInfo;
            if (hit.collider != null && ((1 << hit.collider.gameObject.layer) & buildings) != 0)
            {
                HandleBuildingSelection(hit);
            }
            else
            {
                if (currentSelection != null)
                {
                    currentSelection.SetActive(false);
                }
            }
        }
    }

    void HandleBuildingSelection(RaycastHit hit)
    {
        if (currentSelection != null)
        {
            currentSelection.SetActive(false);
        }
        currentSelection = hit.collider.gameObject.transform.GetChild(0).gameObject;
        currentSelection.SetActive(true);

        if (hit.collider.CompareTag("Keep"))
        {
            Debug.Log("Keep clicked");
        }
    }
}
