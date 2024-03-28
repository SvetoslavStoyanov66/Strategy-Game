using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    Camera myCam;

    public LayerMask clickable;
    public LayerMask ground;

  

    void Start()
    {
        myCam = Camera.main;
    }

    void Update()
    {
      
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray1 = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray1, out hit, Mathf.Infinity, clickable))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                   UnitSelect.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                   UnitSelect.Instance.ClickSelect(hit.collider.gameObject);
                }
            }
            else
            {
               if(!Input.GetKeyDown(KeyCode.LeftShift))
               {
                  UnitSelect.Instance.DeselectAll();
               }
            }

        }

    }
}
