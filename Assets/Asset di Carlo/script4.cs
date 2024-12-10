using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class WaveMesh : MonoBehaviour
{
    public int resolution = 50; // Numero di punti sull'onda
    public float width = 5f; // Larghezza totale dell'onda
    public float amplitude = 1f; // Altezza massima dell'onda
    public float wavelength = 2f; // Lunghezza d'onda
    public float speed = 1f; // Velocità dell'onda
    public float fillHeight = -2f; // Altezza della parte riempita

    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    void Start()
    {
        // Inizializza la mesh
        mesh = new Mesh();
        mesh.name = "Wave Mesh";
        GetComponent<MeshFilter>().mesh = mesh;

        CreateMesh();
    }

    void Update()
    {
        UpdateWave();
    }

    /// <summary>
    /// Crea la mesh iniziale per rappresentare l'onda.
    /// </summary>
    void CreateMesh()
    {
        vertices = new Vector3[resolution * 2]; // Due file di vertici: onda e base
        triangles = new int[(resolution - 1) * 6]; // Triangoli per connettere i vertici
        float step = width / (resolution - 1); // Distanza tra i vertici

        for (int i = 0; i < resolution; i++)
        {
            // Calcola la posizione X centrata
            float x = i * step - width / 2;

            // Crea i vertici superiori (onda) e inferiori (base)
            vertices[i] = new Vector3(x, 0, 0); // Vertice superiore
            vertices[i + resolution] = new Vector3(x, fillHeight, 0); // Vertice inferiore

            // Genera i triangoli per la mesh
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

        // Assegna i dati alla mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    /// <summary>
    /// Aggiorna i vertici per simulare il movimento dell'onda.
    /// </summary>
    void UpdateWave()
    {
        for (int i = 0; i < resolution; i++)
        {
            float x = vertices[i].x; // Coord X locale
            vertices[i].y = Mathf.Sin((x + Time.time * speed) * Mathf.PI * 2 / wavelength) * amplitude; // Movimento sinusoidale
        }

        // Aggiorna i vertici della mesh
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
