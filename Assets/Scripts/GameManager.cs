using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject step1, step2, step3, step4, step5;

    public void Activate2() {

        step1.SetActive(false);
        step2.SetActive(true);
    }

    public void Activate3()
    {
        step2.SetActive(false);
        step3.SetActive(true);

    }

    public void Activate4()
    {
        step3.SetActive(false);
        step4.SetActive(true);

    }

    public void Activate5()
    {
        step4.SetActive(false);
        step5.SetActive(true);

    }
}
