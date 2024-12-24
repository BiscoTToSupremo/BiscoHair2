using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class HeadHairManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Prefab del modello 3D dei capelli da posizionare sulla testa.")]
    private GameObject hairPrefab;

    private ARFaceManager arFaceManager;
    private Dictionary<TrackableId, GameObject> hairInstances = new Dictionary<TrackableId, GameObject>();

    private void Awake()
    {
        arFaceManager = GetComponent<ARFaceManager>();
    }

    private void OnEnable()
    {
        arFaceManager.facesChanged += OnFacesChanged;
    }

    private void OnDisable()
    {
        arFaceManager.facesChanged -= OnFacesChanged;
    }

    private void OnFacesChanged(ARFacesChangedEventArgs args)
    {
        // Aggiungi prefab di capelli per i nuovi volti
        foreach (ARFace face in args.added)
        {
            if (!hairInstances.ContainsKey(face.trackableId))
            {
                GameObject hairInstance = Instantiate(hairPrefab, face.transform);
                hairInstance.transform.SetParent(face.transform); // Assicura che segua la testa
                hairInstance.transform.localPosition = new Vector3(0, 0.15f, 0); // Offset per posizionare sopra la testa
                hairInstance.transform.localRotation = Quaternion.identity;    // Assicura la rotazione corretta
                hairInstances[face.trackableId] = hairInstance;
            }
        }

        // Aggiorna posizione e rotazione per i volti esistenti
        foreach (ARFace face in args.updated)
        {
            if (hairInstances.TryGetValue(face.trackableId, out GameObject hairInstance))
            {
                hairInstance.transform.position = face.transform.position + face.transform.up * 0.15f; // Usa l'asse 'up' per allinearti
                hairInstance.transform.rotation = face.transform.rotation; // Segui l'orientamento della testa
            }
        }

        // Rimuovi prefab di capelli per i volti rimossi
        foreach (ARFace face in args.removed)
        {
            if (hairInstances.TryGetValue(face.trackableId, out GameObject hairInstance))
            {
                Destroy(hairInstance);
                hairInstances.Remove(face.trackableId);
            }
        }
    }
}
