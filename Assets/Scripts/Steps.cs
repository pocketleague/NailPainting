using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{

    public GameManager gameManager;

    public void Step1()
    {
        gameManager.Activate2();
    }

    public void Step2()
    {
        gameManager.Activate3();

    }

    public void Step3()
    {
        gameManager.Activate4();

    }

    public void Step4()
    {
        gameManager.Activate5();

    }

    public void Step5()
    {
      //  gameManager.Activate2();

    }

    public void ChangeCam3()
    {
        gameManager.FilingCamera1();

    }
    public void ChangeCam4()
    {
        gameManager.FilingCamera2();

    }
}
