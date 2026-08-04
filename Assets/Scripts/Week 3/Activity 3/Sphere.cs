using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private Color colour1 = Color.white;
    [SerializeField] private Color colour2 = Color.white;

    private Mesh mesh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
        SetMeshColour();
    }

    private void SetMeshColour()
    {
        //get the negative view direction
        Vector3 viewDirrection = -Camera.main.transform.forward;

        //Initialise the mesh data arrays
        Vector3[] verices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        Color[] colours = new Color[normals.Length];

        for (int i = 0; i < normals.Length; i++) {
            Vector3 relatedNormal = transform.rotation * normals[i];
            float dotProduct = Vector3.Dot(viewDirrection, relatedNormal);
            colours[i] = Color.Lerp(colour1, colour2, dotProduct);
        }

        mesh.colors = colours;
    }
}
