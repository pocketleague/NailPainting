using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material matNew;

    void Start()
    {
        //Material newMat = Material.Instantiate(gameObject.GetComponent<Renderer>().materials[1]);

        //newMat.SetColor("_TopLeftColor", Color.blue);
        //newMat.SetColor("_TopRightolor", Color.blue);

        matNew = gameObject.GetComponent<Renderer>().materials[1];

        matNew.SetColor("_TopLeftColor", Color.blue);
        matNew.SetColor("_TopRightColor", Color.blue);

        print("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);

        Destroy(gameObject, 3);
    }

    void OnDestroy()
    {
        //Destroy the instance
        Destroy(matNew);
        //Output the amount of materials to show if the instance was deleted
        print("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
    }
}
