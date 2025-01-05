using UnityEngine;
using UnityEngine.UI;

public class ScreenshotCapture : MonoBehaviour
{
    public Button screenshotButton; // Assegna questo nel Inspector

    void Start()
    {
        // Assicurati che il pulsante sia assegnato e aggiungi un listener per il click
        if (screenshotButton != null)
        {
            screenshotButton.onClick.AddListener(TakeScreen);
        }
    }

    public void TakeScreen()
    {
        // Disabilita temporaneamente tutti gli elementi UI
        SetUIElementsActive(false);

        // Aspetta un frame per assicurarsi che gli elementi UI siano disabilitati
        StartCoroutine(CaptureScreenshotAfterFrame());
    }

    private System.Collections.IEnumerator CaptureScreenshotAfterFrame()
    {
        yield return new WaitForEndOfFrame();

        // Cattura lo screenshot
        string screenshotName = "Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        ScreenCapture.CaptureScreenshot(screenshotName);

        Debug.Log("Screenshot salvato come: " + screenshotName);

        // Riabilita gli elementi UI
        SetUIElementsActive(true);
    }

    void SetUIElementsActive(bool isActive)
    {
        // Trova tutti gli elementi UI e disabilitali/riabilitali
        Canvas[] canvases = FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in canvases)
        {
            canvas.enabled = isActive;
        }
    }
}