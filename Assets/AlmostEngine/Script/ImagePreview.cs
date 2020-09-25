using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePreview : MonoBehaviour
{
	
	public AlmostEngine.Examples.ValidationCanvas validateCanvas;
    // Start is called before the first frame update
    void Start()
    {
	    Invoke("Capture",0.5f);
    }


	public void Capture()
	{
		validateCanvas.Capture();
		validateCanvas.OnSaveCallback();
	}
	

    // Update is called once per frame
    void Update()
    {
	    
    }
}
