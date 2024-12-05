using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(RectTransform))]
public class WaveDeformer : MonoBehaviour
{
    public float waveSpeed = 2f; // Velocità del movimento dell'onda
    public float maxWaveHeight = 50f; // Altezza massima dell'onda
    public float minWaveHeight = 10f; // Altezza minima dell'onda
    public float maxWaveLength = 200f; // Lunghezza massima delle creste
    public float minWaveLength = 50f; // Lunghezza minima delle creste
    public float swipeThreshold = 200f; // Distanza minima per swipe

    private RectTransform rectTransform;
    private Vector2 initialPosition;
    private Mesh mesh;
    private Vector3[] vertices;
    private float swipeDistance;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition;

        // Genera una mesh per il rettangolo
        mesh = new Mesh();
        GetComponent<UnityEngine.UI.Image>().material.mainTexture = Texture2D.whiteTexture;
        GenerateWaveMesh();
    }

    void Update()
    {
        AnimateWave();

        // Controlla lo swipe verso l'alto
        if (Input.GetMouseButtonDown(0))
            swipeDistance = Input.mousePosition.y;

        if (Input.GetMouseButtonUp(0))
        {
            float swipeEnd = Input.mousePosition.y;
            if (swipeEnd - swipeDistance > swipeThreshold)
                LoadNextScene();
        }
    }

    void GenerateWaveMesh()
    {
        // Generazione dei vertici per la deformazione
        int segmentCount = 20; // Aumenta per una maggiore qualità
        vertices = new Vector3[(segmentCount + 1) * 2];

        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        for (int i = 0; i <= segmentCount; i++)
        {
            float x = width * i / segmentCount;
            vertices[i] = new Vector3(x, height, 0); // Linea superiore
            vertices[i + segmentCount + 1] = new Vector3(x, 0, 0); // Linea inferiore
        }

        int[] triangles = new int[segmentCount * 6];
        for (int i = 0; i < segmentCount; i++)
        {
            int idx = i * 6;
            triangles[idx] = i;
            triangles[idx + 1] = i + 1;
            triangles[idx + 2] = i + segmentCount + 1;

            triangles[idx + 3] = i + segmentCount + 1;
            triangles[idx + 4] = i + 1;
            triangles[idx + 5] = i + segmentCount + 2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        gameObject.AddComponent<MeshRenderer>();
    }

    void AnimateWave()
    {
        float time = Time.time * waveSpeed;

        for (int i = 0; i < vertices.Length / 2; i++)
        {
            float waveLength = Random.Range(minWaveLength, maxWaveLength);
            float waveHeight = Random.Range(minWaveHeight, maxWaveHeight);

            vertices[i].y = Mathf.Sin((vertices[i].x + time) / waveLength) * waveHeight;
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("LoginScene"); // Cambia "LoginScene" con il nome della tua scena
    }
}
