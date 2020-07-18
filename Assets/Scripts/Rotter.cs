using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotter : MonoBehaviour
{
    public float rotSpeed;

    void Start()
    {
            
    }

    void Update()
    {
        transform.Rotate(0, 0, 6.0f * rotSpeed * Time.deltaTime);
    }
}
