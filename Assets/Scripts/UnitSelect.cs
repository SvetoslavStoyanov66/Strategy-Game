using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelect : MonoBehaviour
{
    public List<GameObject> allUnits = new List<GameObject>();
    public List<GameObject> selectedUnits = new List<GameObject>();

    private static UnitSelect _instance;
    public static UnitSelect Instance{get{ return _instance;}}

    void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        selectedUnits.Add(unitToAdd);
    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if(!selectedUnits.Contains(unitToAdd))
        {
            selectedUnits.Add(unitToAdd);
        }
        else
        {
            selectedUnits.Remove(unitToAdd);
        }
    }

    public void DragSelect(GameObject unitToAdd)
    {
    }

    public void DeselectAll()
    {
        selectedUnits.Clear();
    }

    public void Deselect(GameObject unitToDeselect)
    {
    }
}
