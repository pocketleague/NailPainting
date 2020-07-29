using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilingSystem : MonoBehaviour
{
    public GameObject filingTool, filingTool_child, nail;
    public float movement_period;
    public float movement_speed;

    public float movement_periodCntr;
    public bool movingUp;
    public float blendWeight;

    public SkinnedMeshRenderer skinnedMeshRenderer;

    public bool filingDone;
    public GameObject particleEffect1, particleEffect2;

    private Transform startPos, endPos;

    public int filing_step;     // 0-Right Side, 1-Left Side, 2-Top Side

    public GameManager gameManager;

    void Start()
    {
        movement_period = .3f;
        movement_speed = 10;
        filing_step = 0;

        GetFilingData();
    }

    public void GetFilingData()
    {
        if (filing_step == 0)
        {
            startPos = nail.GetComponent<FilingNailData>().startPosR;
            endPos = nail.GetComponent<FilingNailData>().endPosR;
            gameManager.FilingCamera1();

        }
        else if (filing_step == 1)
        {
            startPos = nail.GetComponent<FilingNailData>().startPosL;
            endPos = nail.GetComponent<FilingNailData>().endPosL;
            gameManager.FilingCamera2();

        }
        else if (filing_step == 2)
        {
            startPos = nail.GetComponent<FilingNailData>().startPosU;
            endPos = nail.GetComponent<FilingNailData>().endPosU;
        }


        filingTool.transform.position = startPos.position;
        filingTool.transform.rotation = startPos.rotation;

        blendWeight = 0;
        particleEffect1.SetActive(false);
        particleEffect2.SetActive(false);


        Invoke("ActivateFiling", 2);
    }

    void ActivateFiling()
    {
        filingDone = false;
    }

    void Update()
    {
        if (Input.GetButton("filing") && !filingDone)
        {
            if (filing_step == 0)
            {
                particleEffect1.SetActive(true);
            }
            else if (filing_step == 1)
            {
                particleEffect2.SetActive(true);
            }

            movement_periodCntr += Time.deltaTime;

            if (blendWeight <= 100)
            {
                if (blendWeight <= 50)
                {
                    blendWeight += .1f;
                }
                else
                {
                    blendWeight += .3f;
                }
            }
            else
            {
                filingDone = true;
                filing_step++;
                GetFilingData();
            }
            skinnedMeshRenderer.SetBlendShapeWeight(filing_step, blendWeight);

            float step = (movement_speed / 300) * Time.deltaTime;

            if (Vector3.Distance(filingTool.transform.position, endPos.transform.position) > 0.001f)
            //    if (filingTool.transform.position.y < endPos.transform.position.y)
            {
                filingTool.transform.position = Vector3.MoveTowards(filingTool.transform.position, endPos.transform.position, step);
            }

            if (movingUp)
            {
                filingTool_child.transform.position += filingTool_child.transform.forward * Time.deltaTime * movement_speed;
             //   filingTool_child.transform.position += filingTool_child.transform.up * Time.deltaTime * (movement_speed / 100);
                if (movement_periodCntr > movement_period)
                {
                    movement_periodCntr = 0;
                    movingUp = false;
                }
            }
            else
            {
                filingTool_child.transform.position += filingTool_child.transform.forward * Time.deltaTime * -movement_speed;
                //  filingTool.transform.position += filingTool.transform.up * Time.deltaTime * (movement_speed / 100);

                if (movement_periodCntr > movement_period)
                {
                    movement_periodCntr = 0;
                    movingUp = true;
                }
                //}
            }
        }
        else
        {
            if (filing_step == 0)
            {
                particleEffect1.SetActive(false);
            }
            else if (filing_step == 1)
            {
                particleEffect2.SetActive(false);
            }
        }


    }
}
