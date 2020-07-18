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
            Debug.Log("kkkk");

            skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
        }

        if (col.gameObject.tag == "normalNail")
        {
            particles.Stop();
        }
    }


    void OnMouseDown()
    {
        Debug.Log("ddddd");
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;

        if (cursorPosition.z >= transform.position.z)
        {
            blendWeight += 0.5f;
            brushTip.SetBlendShapeWeight(0, blendWeight);
        }
        else
        {
            if (blendWeight > 0)
            {
                blendWeight -= 0.5f;
            }

            brushTip.SetBlendShapeWeight(0, blendWeight);
        }
        transform.position = new Vector3(cursorPosition.x * 1f, gameObject.transform.position.y, cursorPosition.z);


        if (brushTip.transform.position.x > 0)
        {
            onRightSide = true;
            onLeftSide = false;

            Debug.Log("on left side");
            brushModel.transform.localRotation = Quaternion.Euler(0.9f, -89, -10);

        }
        else
       // if(!onLeftSide)
        {
            onLeftSide = true;
            onRightSide = false;
            Debug.Log("on right side");
            brushModel.transform.localRotation = Quaternion.Euler(0.9f, -89, 40);

        }
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
        brushTip.SetBlendShapeWeight(0, 0);
        blendWeight = 0;


    }
}
