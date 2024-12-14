using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class HairAttachment : MonoBehaviour {
    public GameObject hairPrefab; // Modello di capelli
    private ARFaceManager arFaceManager;

    void Start() {
        // Trova ARFaceManager nella scena
        arFaceManager = FindObjectOfType<ARFaceManager>();

        if (arFaceManager == null) {
            Debug.LogError("ARFaceManager non trovato nella scena!");
            return;
        }

        // Assegna un evento per aggiungere i capelli
        arFaceManager.facesChanged += OnFacesChanged;
    }

    void OnFacesChanged(ARFacesChangedEventArgs args) {
        // Aggiungi capelli per ogni nuovo volto rilevato
        foreach (ARFace face in args.added) {
            AttachHairToFace(face);
        }
    }

    void AttachHairToFace(ARFace face) {
    // Istanzia il prefab dei capelli
    GameObject hairInstance = Instantiate(hairPrefab, face.transform);

    // Allinea il modello dei capelli con il volto
    hairInstance.transform.localPosition = new Vector3(0f, 0.1f, -0.1f); // Sposta leggermente indietro
    hairInstance.transform.localRotation = Quaternion.identity; // Mantieni orientamento
    hairInstance.transform.localScale = new Vector3(1f, 1f, 1f); // Mantieni scala
}


    void OnDestroy() {
        // Rimuovi l'evento quando lo script viene distrutto
        if (arFaceManager != null)
            arFaceManager.facesChanged -= OnFacesChanged;
    }
}

