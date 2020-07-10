using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obi
{
    public class Move : MonoBehaviour
    {
        private Touch touch;
        private float speedModifier;

        private Vector3 screenPoint;
        private Vector3 offset;
        public Vector3 startPos;


        void Start()
        {
            speedModifier = 0.01f;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {

                }
            }

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {

                }
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(transform.position.x + (touch.deltaPosition.x * speedModifier),
                                        transform.position.y,
                                        transform.position.z + (touch.deltaPosition.y * speedModifier));

                }
                if (touch.phase == TouchPhase.Ended)
                {
                    CancelInvoke("Delay");
                    Debug.Log("gggggggggg cancelled crushing");
                }
            }
        }

        void OnMouseDown()
        {
            SingletonClass.instance.IS_PRESSED = true;

            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }

        void OnMouseDrag()
        {
            Debug.Log("ddddd dragging");

            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = new Vector3(cursorPosition.x * 1f, gameObject.transform.position.y, cursorPosition.z);
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
            Debug.Log("ddddd mouse up");

            SingletonClass.instance.IS_PRESSED = false;
        }
    }
}