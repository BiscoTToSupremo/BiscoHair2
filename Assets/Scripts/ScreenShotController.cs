using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using TMPro;
using UnityEngine.Android; // Per gestire i permessi su Android

public class ScreenshotController : MonoBehaviour
{
    public Button screenshotButton; // Riferimento al pulsante
    public TMP_Text feedbackText; // Riferimento a un testo per il feedback
    private string screenshotPath;  // Percorso per salvare lo screenshot

    void Start()
    {
        // Percorso per salvare gli screenshot (nella cartella persistente del dispositivo)
        screenshotPath = Path.Combine(Application.persistentDataPath, "Screenshots");
        if (!Directory.Exists(screenshotPath))
        {
            Directory.CreateDirectory(screenshotPath);
        }

        // Assicurati che il feedback text sia disattivato all'inizio
        if (feedbackText != null)
        {
            feedbackText.gameObject.SetActive(false);
        }

        // Richiedi il permesso di scrittura su Android
        RequestWritePermission();
    }

    // Richiede il permesso di scrittura su Android
    private void RequestWritePermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
    }

    public void TakeScreenshot()
    {
        // Disattiva il pulsante
        screenshotButton.interactable = false;

        // Scatta lo screenshot
        StartCoroutine(CaptureScreenshot());
    }

    private IEnumerator CaptureScreenshot()
    {
        yield return new WaitForEndOfFrame(); // Aspetta che il frame corrente finisca

        // Genera un nome unico per lo screenshot
        string screenshotFileName = $"Screenshot_{System.DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
        string filePath = Path.Combine(screenshotPath, screenshotFileName);

        // Crea la texture per lo screenshot
        Texture2D screenshotTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshotTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshotTexture.Apply();

        // Salva l'immagine come file PNG
        byte[] imageBytes = screenshotTexture.EncodeToPNG();
        File.WriteAllBytes(filePath, imageBytes);

        Debug.Log($"Screenshot salvato in: {filePath}");

        // Mostra un feedback visivo
        if (feedbackText != null)
        {
            feedbackText.text = $"Screenshot salvato in: {filePath}";
            feedbackText.gameObject.SetActive(true);
            yield return new WaitForSeconds(2); // Mostra il feedback per 2 secondi
            feedbackText.gameObject.SetActive(false);
        }

        // Rendi il pulsante di nuovo cliccabile
        screenshotButton.interactable = true;

        // Elimina la texture per liberare memoria
        Destroy(screenshotTexture);
    }
}