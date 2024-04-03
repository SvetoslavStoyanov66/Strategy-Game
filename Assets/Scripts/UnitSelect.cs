using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelect : MonoBehaviour
{
    public List<GameObject> allUnits = new List<GameObject>();
    public List<GameObject> selectedUnits = new List<GameObject>();

    public static UnitSelect Instance{get;set;}

    public Vector3 rayCastPosition = new Vector3();

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void SelectUnitIndicator(GameObject unit,bool active)
    {
        unit.transform.GetChild(0).gameObject.SetActive(active);
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        selectedUnits.Add(unitToAdd);
        SelectUnitIndicator(unitToAdd,true);
    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if(!selectedUnits.Contains(unitToAdd))
        {
            selectedUnits.Add(unitToAdd);
            SelectUnitIndicator(unitToAdd,true);
        }
        else if(selectedUnits.Contains(unitToAdd))
        {
            SelectUnitIndicator(unitToAdd,false);
            selectedUnits.Remove(unitToAdd);
        }
    }

    public void DragSelect(GameObject unitToAdd)
    {
        if(!selectedUnits.Contains(unitToAdd))
        {
            selectedUnits.Add(unitToAdd);
            SelectUnitIndicator(unitToAdd,true);
        }
    }

    public void DeselectAll()
    {
        foreach(GameObject unit in selectedUnits)
        {
            SelectUnitIndicator(unit,false);
        }
        selectedUnits.Clear();
    }

    public void Deselect(GameObject unitToDeselect)
    {
    }
}
