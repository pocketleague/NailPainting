using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisintegrateDrop : MonoBehaviour
{

    public bool startDisintegrating, startMelting;
    public GameObject tipBrush;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "brushTip" && gameObject.name != "droplet")
        {
            if (!startDisintegrating)
            {
                startDisintegrating = true;

                gameObject.transform.parent = other.gameObject.transform;
                tipBrush = other.gameObject;
              //  other.gameObject.GetComponent<Es.InkPainter.Sample.CollisionPainter>().startPainting = true;

                other.gameObject.GetComponent<Es.InkPainter.Sample.CollisionPainter>().dropCounter++;
            }

        }
    }

    private void Update()
    {
        if (startDisintegrating)
        {
            if (transform.localScale.x > 0 && transform.localScale.y > 0 && transform.localScale.z > 0)
            {
                transform.localScale -= new Vector3(0.008f, 0.008f, 0.008f);
            }
            else
            {
                if (tipBrush.gameObject.GetComponent<Es.InkPainter.Sample.CollisionPainter>().dropCounter < 4)
                {
                 //   tipBrush.GetComponent<Es.InkPainter.Sample.CollisionPainter>().startPainting = false;
                }
                startDisintegrating = false;

                gameObject.SetActive(false);
            }
        }

        // for starting melting effect of the drop
        // melting it for small amount
        if (startMelting)
        {
            if (gameObject.GetComponent<MegaMelt>().Amount < 20)
            {
                gameObject.GetComponent<MegaMelt>().Amount += .7f;
            }
            else {
                startMelting = false;
            }

        }
    }
}
