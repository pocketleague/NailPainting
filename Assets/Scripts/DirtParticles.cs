using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtParticles : MonoBehaviour
{
    private bool IsRemoved;

    public void FallOff()
    {
        if (!IsRemoved)
        {
            IsRemoved = true;

            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0, 5), 20, Random.Range(0, 5));
        }
    }
}
