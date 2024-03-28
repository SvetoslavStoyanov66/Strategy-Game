using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    void Start()
    {
        UnitSelect.Instance.allUnits.Add(this.gameObject);
    }
    void Destroy()
    {
        UnitSelect.Instance.allUnits.Remove(this.gameObject);
    }
}
