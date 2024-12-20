using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARFace))]
public class HairPositionerNew : MonoBehaviour
{
    public GameObject hairPrefab;  // Prefab dei capelli
    public float verticalOffset = 0.05f; // Offset per regolare la posizione verticale dei capelli
    private ARFace arFace;  // Riferimento al componente ARFace

    private GameObject hairInstance; // Riferimento alla copia del prefab dei capelli

    void Start()
    {
        // Otteniamo il componente ARFace
        arFace = GetComponent<ARFace>();

        if (arFace == null)
        {
            Debug.LogError("ARFace component not found on this object.");
            return;
        }

        if (hairPrefab == null)
        {
            Debug.LogError("Hair prefab not assigned! Please assign a hair prefab.");
            return;
        }

        // Instanziamo il prefab dei capelli all'inizio
        hairInstance = Instantiate(hairPrefab);
        hairInstance.SetActive(false); // Nascondiamo i capelli inizialmente
    }

    void Update()
    {
        if (arFace != null && hairInstance != null)
        {
            // Verifica che la faccia sia tracciata
            if (arFace.trackingState != TrackingState.Tracking)
                return;

            // Otteniamo la posizione della testa
            Vector3 headPosition = GetHeadPositionNew(arFace);

            // Applichiamo un offset verticale per posizionare meglio i capelli sopra la testa
            headPosition.y += verticalOffset;

            // Posizioniamo e ruotiamo i capelli
            hairInstance.transform.position = headPosition;
            hairInstance.transform.rotation = arFace.transform.rotation;

            // Mostriamo i capelli
            hairInstance.SetActive(true);
        }
    }

    // Funzione per ottenere la posizione della testa dalla faccia tracciata
    private Vector3 GetHeadPositionNew(ARFace face)
    {
        // Ritorna la posizione del punto medio della faccia, che dovrebbe essere sopra la testa
        return face.transform.position;
    }
}
