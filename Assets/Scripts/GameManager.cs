using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject step1, step2, step3, step4, step5;
    public GameObject paintColors, paintMix;
    public GameObject colorButtons;
    public GameObject cam1, cam2, cam3, cam4, cam_allfinger;

    public static float normalMapValue;

    public Es.InkPainter.Sample.CollisionPainter brushCollisionPainter;

    public GameObject droplet;
    public Transform brushTip;

    public GameObject confetti1, confetti2;

    private void Start()
    {
        normalMapValue = 2;
    }
    private void Update()
    {
        //
        if (Input.GetButtonDown("Jump"))
        {
            // To move to the next step
            NextButton();
        }

        //if (Input.GetButtonDown("pickDrop"))
        //{
        //    brushCollisionPainter.droplet = Instantiate(droplet, brushCollisionPainter.transform.position, Quaternion.identity, brushCollisionPainter.transform);
        //}
        //if (Input.GetButtonDown("spread"))
        //{
        //    brushCollisionPainter.startPainting = true;
        //    brushCollisionPainter.droplet.GetComponent<DisintegrateDrop>().startDisintegrating = true;
        //}
    }

    public void Activate2() {

        step1.SetActive(false);
        step2.SetActive(true);
    }

    public void Activate3()
    {
        step2.SetActive(false);
        step3.SetActive(true);

        cam4.SetActive(false);
        cam1.SetActive(true);
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

        cam1.SetActive(false);
        cam2.SetActive(true);
    }

    public void FilingCamera1()
    {
        cam1.SetActive(false);
        cam3.SetActive(true);
    }

    public void FilingCamera2()
    {
        cam3.SetActive(false);
        cam4.SetActive(true);
    }


    // To move to the next step
    public void NextButton()
    {
        if (SingletonClass.instance.STEP_NO == 0)
        {
            SingletonClass.instance.STEP_NO++;
            step1.SetActive(false);
            step2.SetActive(true);

        }
        else if (SingletonClass.instance.STEP_NO == 1)
        {
            step2.GetComponent<Animator>().SetBool("sticketOut", true);

            step2.transform.Find("Shape key curved nail").GetComponent<BoxCollider>().enabled = false;

            Invoke("DelayStep3", 3);
        }
        else if (SingletonClass.instance.STEP_NO == 2)
        {
            brushCollisionPainter.startPainting = true;

            Invoke("DelayStep4", 1);
        }
        else if (SingletonClass.instance.STEP_NO == 3)
        {
            SingletonClass.instance.STEP_NO++;

            cam1.SetActive(false);
            cam_allfinger.SetActive(true);

            confetti1.SetActive(true);
            confetti2.SetActive(true);

            Invoke("DelayStep5", 4);
        }

    }

    void DelayStep3()
    {
        SingletonClass.instance.STEP_NO++;
     
        step2.SetActive(false);

        step3.SetActive(true);
        brushCollisionPainter.startPainting = true;
    }


    void DelayStep4()
    {
        SingletonClass.instance.STEP_NO++;
        step3.SetActive(false);

        step4.SetActive(true);
        brushCollisionPainter.startPainting = true;

        normalMapValue = 0.2f;

    }

    void DelayStep5()
    {
        //confetti1.SetActive(false);
        //confetti2.SetActive(false);
    }

    void DisableAnimator()
    {
        step2.GetComponent<Animator>().enabled = false;

    }
}
