using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARCameraManager))]
public class SetCameraFacing : MonoBehaviour
{
    private void Start()
    {
        // Ottieni il componente ARCameraManager
        ARCameraManager cameraManager = GetComponent<ARCameraManager>();

        // Imposta la videocamera frontale
        if (cameraManager != null)
        {
            cameraManager.requestedFacingDirection = CameraFacingDirection.User;
        }
    }
}
