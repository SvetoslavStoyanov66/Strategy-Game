using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastManager : MonoBehaviour
{
    public static RayCastManager Instance{get;set;}
    

    Camera mainCamera;
    public RaycastHit hitInfo;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hitInfo, Mathf.Infinity);
    }
}
