using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisintegrateDrop : MonoBehaviour
{

    public bool startDisintegrating;
    public GameObject tipBrush;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "brushTip")
        {
            if (!startDisintegrating)
            {
                startDisintegrating = true;

                gameObject.transform.parent = other.gameObject.transform;
                tipBrush = other.gameObject;
                other.gameObject.GetComponent<Es.InkPainter.Sample.CollisionPainter>().startPainting = true;
            }

        }
    }

    private void Update()
    {
        if (startDisintegrating)
        {
            
            //if (transform.position.y > 2.242584f)
            //{

            //    if (transform.localScale.x > 0 && transform.localScale.y > 0 && transform.localScale.z > 0)
            //    {
            //        transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
            //    }
            //    transform.position -= new Vector3(0, 0.002f, 0);
            //}
            //else
            //{
            //    startDisintegrating = false;
            //    tipBrush.GetComponent<Es.InkPainter.Sample.CollisionPainter>().startPainting = false;
            //    gameObject.SetActive(false);
            //}

            if (transform.localScale.x > 0 && transform.localScale.y > 0 && transform.localScale.z > 0)
            {
                //transform.localScale -= new Vector3(-0.001f, 0.005f, -0.003f);
                transform.localScale -= new Vector3(0.004f, 0.004f, 0.004f);

             //  transform.position -= new Vector3(0, 0.001f, 0);

            }
            else
            {
                startDisintegrating = false;
                tipBrush.GetComponent<Es.InkPainter.Sample.CollisionPainter>().startPainting = false;

                gameObject.SetActive(false);
            }


        }
    }
}
