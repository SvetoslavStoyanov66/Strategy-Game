using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    Transform transform;
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }
    void Update()
    {
        transform.position += new Vector3(0.01f,0,0);
    }
}
