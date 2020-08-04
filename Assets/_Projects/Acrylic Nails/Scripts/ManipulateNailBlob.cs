using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateNailBlob : MonoBehaviour
{
    [SerializeField] private MeshFilter     _nailBlob;
    [SerializeField] private MeshFilter     _nailFinished;
    [SerializeField] private Transform      _toolRaycastPoint;
    [SerializeField] private float          _radius;
    [SerializeField] private float          _strength;
    [SerializeField] private AnimationCurve _falloff;
    [SerializeField] private Transform      _marker;

    private Vector3[] _blobVertices;
    private Vector3[] _nailVertices;

    private Vector3      _startPos;
    private bool         _manipulating;
    private Mesh         _mesh;
    private MeshCollider _meshCollider;
    private Transform    _transform;

    private Dictionary<int, float> _pointsNormalizedPos; // int = vertex index , float = 0 to 1 represent the lerp value between _nailBlob to _nailFinished

    private void Awake()
    {
        InputManager.inst.OnClickCallback    += StartManipulate;
        InputManager.inst.OnDragCallback     += Manipulate;
        InputManager.inst.OnClickEndCallback += EndManipulate;

        _mesh         = GetComponent<MeshFilter>().mesh;
        _meshCollider = GetComponent<MeshCollider>();

        InitPointsNormalizedPosTable();

        _blobVertices = _nailBlob.sharedMesh.vertices;
        _nailVertices = _nailFinished.sharedMesh.vertices;

        _marker.localScale = Vector3.one * _radius;

        _transform = transform;
    }

    private void InitPointsNormalizedPosTable()
    {
        _pointsNormalizedPos = new Dictionary<int, float>();

        for (int i = 0; i < _mesh.vertexCount; i++)
            _pointsNormalizedPos.Add(i, 0f);
    }

    private void StartManipulate(Vector2 startPos)
    {
        Debug.Log("ggigig");

        RaycastHit hit;
        Ray ray = new Ray(_toolRaycastPoint.position, _toolRaycastPoint.forward);

        if(Physics.SphereCast(ray, _radius, out hit, Mathf.Infinity, LayerMask.GetMask("Nail")))
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Nail")))
        {
            _manipulating    = true;
            _startPos        = hit.point;
            _marker.position = hit.point;
        }
        else
        {
            _manipulating = false;
        }
    }

    private void Manipulate(Vector2 currentPos)
    {
        RaycastHit hit;
        bool wasHit = false;
        Ray ray     = new Ray(_toolRaycastPoint.position, _toolRaycastPoint.forward);

        if (Physics.SphereCast(ray, _radius, out hit, Mathf.Infinity, LayerMask.GetMask("Nail")))
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Nail")))
            wasHit = true;

        if (_manipulating && wasHit)
        {
            MoveVertices(hit.point);
            _marker.position = hit.point;
        }
        else if(wasHit)
        {
            _manipulating    = true;
            _startPos        = hit.point;
            _marker.position = hit.point;
        }
    }

    private void EndManipulate(Vector2 endPos)
    {
        _manipulating = false;
    }

    private void MoveVertices(Vector3 hitPos)
    {
        Vector3[] vertices = _mesh.vertices;
        float dist;
        float influence;

        for (int i = 0; i < vertices.Length; i++)
        {
            dist      = Vector3.Distance(hitPos, _transform.TransformPoint(vertices[i]));
            influence = _falloff.Evaluate(Mathf.Clamp(1 - (dist / _radius), 0f, 1f));

            _pointsNormalizedPos[i] += influence * _strength * 0.001f; 

            vertices[i] = Vector3.Lerp(_blobVertices[i], _nailVertices[i], _pointsNormalizedPos[i]);
        }

        _mesh.vertices = vertices;
        _mesh.RecalculateNormals();
        _meshCollider.sharedMesh = _mesh;
    }
}
