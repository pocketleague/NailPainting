﻿// This asset was uploaded by http://unityassetcollection.com/
using UnityEngine;

[ExecuteInEditMode]
public class MegaScroll : MonoBehaviour
{
	public float pos = 0.0f;
	public float gap = 0.5f;

	public Vector3	wpos;

	MegaBend[]	bends;

	void Update()
	{
		if ( bends == null )
		{
			bends = GetComponents<MegaBend>();
		}

		bends[1].gizmoPos.x = pos - gap;
		bends[0].gizmoPos.x = pos + gap;

		Vector3 p = transform.position;

		p.x = wpos.x + pos;
		transform.position = p;
	}
}