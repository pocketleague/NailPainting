using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    public GameObject nail;

    void Start()
    {
        gameObject.GetComponent<Renderer>().sharedMaterials[1].SetColor("_Color", Color.red);
    }
}
