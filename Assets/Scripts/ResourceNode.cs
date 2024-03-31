using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    [SerializeField]
    public int resourcesAmount;

    public void Digging()
    {
        resourcesAmount--;
        if(resourcesAmount <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
