using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject step1, step2, step3, step4, step5;
    public GameObject paintColors, paintMix;
    public GameObject colorButtons;
    public GameObject cam1, cam2, cam3, cam4;

    public static float normalMapValue;

    public Es.InkPainter.Sample.CollisionPainter brushCollisionPainter;

    public GameObject droplet;
    public Transform brushTip;


    private void Start()
    {
        normalMapValue = .5f;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (SingletonClass.instance.STEP_NO == 0)
            {
                SingletonClass.instance.STEP_NO++;
                step1.SetActive(false);
                step2.SetActive(true);

            }
            else if (SingletonClass.instance.STEP_NO == 1)
            {
                SingletonClass.instance.STEP_NO++;
                step2.SetActive(false);
                step3.SetActive(true);

                brushCollisionPainter.startPainting = true;
                InvokeRepeating("ReduceValue", 0.1f, 0.1f);
            }

          
        }

        if (Input.GetButtonDown("pickDrop"))
        {
            Debug.Log("ppp");
            brushCollisionPainter.droplet = Instantiate(droplet, brushCollisionPainter.transform.position, Quaternion.identity, brushCollisionPainter.transform);
        }
        if (Input.GetButtonDown("spread"))
        {
            brushCollisionPainter.startPainting = true;
            brushCollisionPainter.droplet.GetComponent<DisintegrateDrop>().startDisintegrating = true;
        }
    }

    void ReduceValue()
    {
        if (normalMapValue > 0)
        {
            normalMapValue -= 0.01f;
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

        cam4.SetActive(false);
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
}
