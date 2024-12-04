using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class WaveMesh : MonoBehaviour
{
    public int resolution = 50;       // Numero di punti dell'onda
    public float width = 5f;         // Larghezza dell'onda
    public float amplitudeMin = 0.5f; // Altezza minima casuale dell'onda
    public float amplitudeMax = 1.5f; // Altezza massima casuale dell'onda
    public float wavelengthMin = 2f; // Lunghezza d'onda minima casuale
    public float wavelengthMax = 5f; // Lunghezza d'onda massima casuale
    public float speed = 1f;         // Velocità di animazione
    public float fillHeight = -2f;   // Altezza del riempimento

    private float amplitude;         // Altezza attuale dell'onda
    private float wavelength;        // Lunghezza d'onda attuale
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // Genera valori casuali per altezza e lunghezza d'onda
        amplitude = Random.Range(amplitudeMin, amplitudeMax);
        wavelength = Random.Range(wavelengthMin, wavelengthMax);

        CreateMesh();
    }

    void Update()
    {
        UpdateWave();
    }

    void CreateMesh()
    {
        // Inizializza vertici e triangoli
        vertices = new Vector3[resolution * 2]; // Due file di vertici
        triangles = new int[(resolution - 1) * 6]; // Triangoli

        float step = width / (resolution - 1);

        for (int i = 0; i < resolution; i++)
        {
            // Vertici superiori (onda)
            vertices[i] = new Vector3(i * step, 0, 0);

            // Vertici inferiori (base dell'onda)
            vertices[i + resolution] = new Vector3(i * step, fillHeight, 0);

            // Crea triangoli
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
        // Calcola un fattore di scala per la velocità
        float scaledSpeed = speed * 0.1f;

        // Anima i vertici superiori
        for (int i = 0; i < resolution; i++)
        {
            float x = vertices[i].x;
            vertices[i].y = Mathf.Sin((x + Time.time * scaledSpeed) * Mathf.PI * 2 / wavelength) * amplitude;
        }

        // Aggiorna la mesh
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
