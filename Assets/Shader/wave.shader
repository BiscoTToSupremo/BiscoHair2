using UnityEngine;

public class WaveMesh : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] originalVertices;
    public float frequency = 1.0f;
    public float amplitude = 1.0f;
    public float speed = 1.0f;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh; // Ottieni la mesh del plane
        originalVertices = mesh.vertices; // Salva i vertici originali
    }

    void Update()
    {
        AnimateWave(); // Chiama la funzione che anima l'onda
    }

    void AnimateWave()
    {
        Vector3[] vertices = new Vector3[originalVertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = originalVertices[i];
            vertex.y += Mathf.Sin(Time.time * speed + vertex.x * frequency) * amplitude;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices; // Applica i nuovi vertici
        mesh.RecalculateNormals(); // Ricalcola le normali della mesh per illuminazione corretta
    }
}
