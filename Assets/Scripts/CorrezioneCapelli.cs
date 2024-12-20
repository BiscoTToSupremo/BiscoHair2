using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class HairPositioner : MonoBehaviour
{
    public GameObject hairPrefab;  // Prefab dei capelli
    public float verticalOffset = 0.1f; // Offset verticale per regolare la posizione dei capelli
    private ARFace arFace;  // Riferimento al componente ARFace
    private GameObject hairInstance; // Riferimento al prefab dei capelli

    void Start()
    {
        // Ottieni il componente ARFace dall'oggetto corrente
        arFace = GetComponent<ARFace>();

        if (arFace == null)
        {
            Debug.LogError("ARFace component not found!");
            return;
        }

        if (hairPrefab == null)
        {
            Debug.LogError("Hair prefab not assigned!");
            return;
        }

        // Instanzia il prefab dei capelli
        hairInstance = Instantiate(hairPrefab);
        hairInstance.SetActive(false); // Nascondi i capelli inizialmente
    }

    void Update()
    {
        if (arFace != null && hairInstance != null)
        {
            // Controlla se il viso è tracciato
            if (arFace.trackingState == TrackingState.Tracking)
            {
                // Ottieni la posizione della testa
                Vector3 headPosition = arFace.transform.position;

                // Aggiungi un offset per la posizione verticale dei capelli
                headPosition.y += verticalOffset;

                // Posiziona e ruota i capelli
                hairInstance.transform.position = headPosition;
                hairInstance.transform.rotation = arFace.transform.rotation;

                // Attiva i capelli solo se non sono già visibili
                if (!hairInstance.activeSelf)
                {
                    hairInstance.SetActive(true);
                }
            }
            else
            {
                // Nascondi i capelli quando il viso non è tracciato
                if (hairInstance.activeSelf)
                {
                    hairInstance.SetActive(false);
                }
            }
        }
    }
}
