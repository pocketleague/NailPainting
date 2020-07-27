using UnityEngine;

namespace Es.InkPainter.Sample
{
	[RequireComponent(typeof(Collider), typeof(MeshRenderer))]
	public class CollisionPainter : MonoBehaviour
	{
		[SerializeField]
		private Brush brush = null;

		[SerializeField]
		private int wait = 3;

		private int waitCount;

        public bool startPainting;
        public GameObject droplet;

        public int dropCounter;

        public bool dropRemoved;

        public GameObject target_marker;

        public void Awake()
		{
         //   startPainting = true;

            GetComponent<MeshRenderer>().material.color = brush.Color;
		}

		public void OnCollisionStay(Collision collision)
		{
			//if(waitCount < wait)
			//	return;
			//waitCount = 0;

			//foreach(var p in collision.contacts)
			//{
			//	var canvas = p.otherCollider.GetComponent<InkCanvas>();
			//	if(canvas != null)
			//		canvas.Paint(brush, p.point);
			//}
		}

        void FixedUpdate()
        {

            //  ++waitCount;
            if (true)
            {
                // Bit shift the index of the layer (8) to get a bit mask
                int layerMask = 1 << 8;

                // This would cast rays only against colliders in layer 8.
                // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
                layerMask = ~layerMask;

                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up * -1), out hit, Mathf.Infinity, layerMask))
                {
                    
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * -1 * hit.distance, Color.yellow);

                    if (!startPainting && hit.collider.tag == "droplet")
                    {
                        Debug.Log("detected");
                        startPainting = true;
                    }

                    if (!startPainting)
                    {
                        return;
                    }

                    if (hit.collider.tag == "nail")
                    {
                        //foreach (var p in hit.point)
                        //{
                        var canvas = hit.collider.GetComponent<InkCanvas>();
                        if (canvas != null)
                        {
                            if (droplet != null)
                            {
                                if (droplet.GetComponent<MegaMelt>().Amount < 150)
                                {
                                    droplet.GetComponent<MegaMelt>().Amount += 1;
                                }
                                else
                                {
                                    if (!dropRemoved)
                                    {
                                        dropRemoved = true;
                                        Invoke("Deactivate", 2);
                                    }
                                }

                            }
                            canvas.Paint(brush, hit.point);

                            target_marker.SetActive(true);
                            Vector3 pos = new Vector3(hit.point.x, hit.point.y + .4f, hit.point.z);
                            target_marker.transform.position = pos;
                        }
                        // }
                    }
                    else
                    {
                        target_marker.SetActive(false);

                    }

                    //if (hit.collider.tag == "leftSideNail")
                    //{
                    //    Debug.Log("leftSideNail");
                    //}

                    //if (hit.collider.tag == "rightSideNail")
                    //{
                    //    Debug.Log("rightSideNail");
                    //}
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                    Debug.Log("Did not Hit");
                }
            }
        }
        void Deactivate()
        {
            droplet.SetActive(false);
        }
    }
}