using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;

    public SkinnedMeshRenderer skinnedMeshRenderer;

    private Vector3 screenPoint;
    private Vector3 offset;
    public Vector3 startPos;

    public ParticleSystem particles;

    public SkinnedMeshRenderer brushTip;
    private float blendWeight;

    public Transform acrylicNailPos;
    public Transform brushModel;
    public bool onRightSide;
    public bool onLeftSide;

    private Vector3 lastPos;

    void Start()
    {
        startPos = transform.position;
        speedModifier = 0.013f;

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {

            }
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x - (touch.deltaPosition.x * speedModifier),
                                    transform.position.y,
                                    transform.position.z - (touch.deltaPosition.y * speedModifier));

            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "nail")
        {
            Debug.Log("kkkk");
            skinnedMeshRenderer.SetBlendShapeWeight(0, 100);
        }

        if (col.gameObject.tag == "normalNail")
        {
            Debug.Log("tttt");
            particles.Play();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "nail")
        {
            skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
        }

        if (col.gameObject.tag == "normalNail")
        {
            particles.Stop();
        }
    }


    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        lastPos = transform.position;

    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
       
        transform.position = new Vector3(cursorPosition.x * 1, gameObject.transform.position.y, cursorPosition.z);

        Vector3 dir = (lastPos - transform.position);

      //  Debug.Log("pppp dir "+dir);

        if (SingletonClass.instance.STEP_NO == 1 || SingletonClass.instance.STEP_NO == 3)
        {
            if (dir.z > 0)
            {
                Debug.Log("ppppp its moving up");//+ cursorPosition.z
                blendWeight += 1f;
                brushTip.SetBlendShapeWeight(0, blendWeight);
            }
            else if (dir.z < 0)
            {
                Debug.Log("ppppp its moving down");//+ cursorPosition.z
                if (blendWeight > 0)
                {
                    blendWeight -= 1f;
                }
                brushTip.SetBlendShapeWeight(0, blendWeight);
            }
            else
            {
                Debug.Log("ppppp its not moving ");//+ cursorPosition.z +" : "+transform.position.z)

                if (blendWeight > 0)
                {
                    blendWeight -= 1f;
                }
                brushTip.SetBlendShapeWeight(0, blendWeight);
            }


            //if (cursorPosition.z >= transform.position.z)
            //{
            //    blendWeight += 1f;
            //    brushTip.SetBlendShapeWeight(0, blendWeight);
            //}
            //else
            //{
            //    if (blendWeight > 0)
            //    {
            //        blendWeight -= 1f;
            //    }
            //    brushTip.SetBlendShapeWeight(0, blendWeight);
            //}

            if (brushTip.transform.position.x > 0)       // left side
            {
                onRightSide = false;
                onLeftSide = true;

           //     Debug.Log("on left side");
                //   brushModel.transform.localRotation = Quaternion.Euler(0.9f, -89, -10);
                brushModel.transform.localRotation = Quaternion.Euler(-52, -11, -30);
            }
            else
            // if(!onLeftSide)
            {
                onLeftSide = false;
                onRightSide = true;

       //         Debug.Log("on right side");
                //   brushModel.transform.localRotation = Quaternion.Euler(0.9f, -89, 40);
                brushModel.transform.localRotation = Quaternion.Euler(-52, -11, 30);
            }
        }

        lastPos = transform.position;



    }

    void OnMouseUp()
    {
        //if (!EventSystem.current.IsPointerOverGameObject())
        //{
        //    CancelInvoke("Delay");
        //    SingletonClass.instance.IS_CRUSHING = false;
        //    animator_hand.SetBool("crushing", false);
        //    //   animator_soap.SetBool("crushing", false);
        //    soapParent.GetChild(0).GetComponentInChildren<Animator>().SetBool("crushing", false);
        //}

        if (SingletonClass.instance.STEP_NO == 2)
        {
            brushTip.SetBlendShapeWeight(0, 0);
            blendWeight = 0;
        }


    }
}
