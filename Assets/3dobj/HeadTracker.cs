using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class HeadTracker : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Prefab del modello 3D dei capelli.")]
    private GameObject hairPrefab;

    [SerializeField]
    [Tooltip("Offset verticale per posizionare i capelli correttamente sopra la testa.")]
    private float verticalOffset = 0.1f;

    [SerializeField]
    [Tooltip("Offset per regolare la profondità del posizionamento.")]
    private float depthOffset = 0.0f;

    private GameObject hairInstance;
    private Transform headAnchor;

    private ARHumanBodyManager humanBodyManager;

    private void Start()
    {
        // Cerca ARHumanBodyManager nella scena
        humanBodyManager = FindObjectOfType<ARHumanBodyManager>();
        if (humanBodyManager == null)
        {
            Debug.LogError("ARHumanBodyManager non trovato nella scena. Aggiungilo per abilitare il tracciamento del corpo.");
            enabled = false;
            return;
        }

        // Crea un punto di ancoraggio per la testa
        headAnchor = new GameObject("HeadAnchor").transform;

        // Crea l'istanza del prefab dei capelli
        if (hairPrefab != null)
        {
            hairInstance = Instantiate(hairPrefab, headAnchor);
        }
    }

    private void Update()
    {
        // Verifica se ci sono corpi tracciati
        if (humanBodyManager.trackables.count == 0)
        {
            Debug.LogWarning("Nessun corpo tracciato.");
            return;
        }

        // Ottieni il primo corpo tracciato
        foreach (ARHumanBody body in humanBodyManager.trackables)
        {
            UpdateHairPosition(body);
            break;
        }
    }

    private void UpdateHairPosition(ARHumanBody humanBody)
    {
        if (hairInstance != null && humanBody != null)
        {
            // Posizione approssimativa della testa usando il corpo
            Vector3 headPosition = humanBody.transform.position + Vector3.up * 0.2f; // Aggiustamento approssimativo
            Quaternion headRotation = humanBody.transform.rotation;

            // Applica offset e aggiorna posizione e rotazione
            hairInstance.transform.position = headPosition + Vector3.up * verticalOffset + Vector3.forward * depthOffset;
            hairInstance.transform.rotation = headRotation;
        }
    }
}

