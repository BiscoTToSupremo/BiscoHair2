using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class ScreenshotController : MonoBehaviour
{
    public Button screenshotButton; // Riferimento al pulsante
    private string screenshotPath;  // Percorso per salvare lo screenshot

    void Start()
    {
        // Percorso per salvare gli screenshot (nella cartella persistente del dispositivo)
        screenshotPath = Path.Combine(Application.persistentDataPath, "Screenshots");
        if (!Directory.Exists(screenshotPath))
        {
            Directory.CreateDirectory(screenshotPath);
        }
    }

    public void TakeScreenshot()
    {
        // Disattiva il pulsante
        screenshotButton.gameObject.SetActive(false);

        // Scatta lo screenshot
        StartCoroutine(CaptureScreenshot());

        // Riattiva il pulsante dopo lo scatto
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

        // Rendi visibile il pulsante
        screenshotButton.gameObject.SetActive(true);

        // Elimina la texture per liberare memoria
        Destroy(screenshotTexture);
    }
}
