using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMesh : MonoBehaviour
{
    public Mesh Mesh1;
    public Mesh Mesh2;

    public List<Mesh> meshes;

    private void Start()
    {
   //     var mesh = CombineMeshes(new List<Mesh> { Mesh1, Mesh2 });
        var mesh = CombineMeshes(meshes);

        GetComponent<MeshFilter>().mesh = mesh;
    }

    private Mesh CombineMeshes(List<Mesh> meshes)
    {
        var combine = new CombineInstance[meshes.Count];
        for (int i = 0; i < meshes.Count; i++)
        {
            combine[i].mesh = meshes[i];
            combine[i].transform = transform.localToWorldMatrix;
        }

        var mesh = new Mesh();
        mesh.CombineMeshes(combine);
        return mesh;
    }
}
