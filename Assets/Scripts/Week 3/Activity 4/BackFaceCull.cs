using UnityEngine;
using System.Collections.Generic;

public class BackFaceCull : MonoBehaviour
{
    private Mesh mesh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        CullBackFaces();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CullBackFaces()
    {
        List<int> triangles = new List<int>();
        for (int i = 0; i < mesh.triangles.Length; i = i + 3)
        {
            //Get vectors of the current triangle
            Vector3 v0 = mesh.vertices[mesh.triangles[i + 0]];
            Vector3 v1 = mesh.vertices[mesh.triangles[i + 1]];
            Vector3 v2 = mesh.vertices[mesh.triangles[i + 2]];

            //Create displacement vectors reprosenting the triangle from v0
            Vector3 s0 = v1 - v0;
            Vector3 s1 = v2 - v0;

            //Find the triangles normal
            Vector3 normal = Vector3.Cross(s1, s0);
            Vector3 rotatedNormal = transform.rotation * normal;

            //Find the dot product with the view dirrection
            Vector3 viewDirrection = Camera.main.transform.forward;
            float dotProduct = Vector3.Dot(viewDirrection, rotatedNormal);

            if (dotProduct > 0f)
            {
                triangles.Add(mesh.triangles[i + 0]);
                triangles.Add(mesh.triangles[i + 1]);
                triangles.Add(mesh.triangles[i + 2]);
            }
        }

        mesh.triangles = triangles.ToArray();
    }
}
