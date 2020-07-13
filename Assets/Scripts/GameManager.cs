using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject step1, step2, step3, step4, step5;
    public GameObject paintColors, paintMix;
    public GameObject colorButtons;
    public GameObject cam1, cam2, cam3;

    private int cntr;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (cntr == 0)
            {
                cntr++;
                MixColors();
            }else if (cntr == 1)
            {
                cntr++;
                Activate4();
            }
        }
    }

    public void Activate2() {

        step1.SetActive(false);
        step2.SetActive(true);
    }

    public void Activate3()
    {
        step2.SetActive(false);
        step3.SetActive(true);
        colorButtons.SetActive(true);

        cam1.SetActive(false);
        cam2.SetActive(true);

    }

    public void Activate4()
    {

        colorButtons.SetActive(false);

        step3.SetActive(false);
        step4.SetActive(true);

    }

    public void Activate5()
    {
        step4.SetActive(false);
        step5.SetActive(true);

        cam1.SetActive(true);
        cam2.SetActive(false);

    }

    public void MixColors()
    {
        paintColors.SetActive(false);
        paintMix.SetActive(true);

    }
}
