using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{

    public ParticleSystem particleSystem;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "dirtNail")
        {
            col.gameObject.GetComponent<DirtParticles>().FallOff();

            if (!particleSystem.isEmitting)
            {
            Debug.Log("rrrrr1111");
                particleSystem.Play();
            }
        }
    }
}
