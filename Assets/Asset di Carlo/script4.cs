using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class WaveMesh : MonoBehaviour
{
    public int resolution = 50;
    public float width = 5f;
    public float amplitude = 1f;
    public float wavelength = 2f;
    public float speed = 1f;
    public float fillHeight = -2f;

    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateMesh();
    }

    void Update()
    {
        UpdateWave();
    }

    void CreateMesh()
    {
        vertices = new Vector3[resolution * 2];
        triangles = new int[(resolution - 1) * 6];
        float step = width / (resolution - 1);

        for (int i = 0; i < resolution; i++)
        {
            vertices[i] = new Vector3(i * step, 0, 0);
            vertices[i + resolution] = new Vector3(i * step, fillHeight, 0);

            if (i < resolution - 1)
            {
                int t = i * 6;
                triangles[t] = i;
                triangles[t + 1] = i + resolution;
                triangles[t + 2] = i + 1;
                triangles[t + 3] = i + 1;
                triangles[t + 4] = i + resolution;
                triangles[t + 5] = i + resolution + 1;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    void UpdateWave()
    {
        for (int i = 0; i < resolution; i++)
        {
            float x = vertices[i].x;
            vertices[i].y = Mathf.Sin((x + Time.time * speed) * Mathf.PI * 2 / wavelength) * amplitude;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
