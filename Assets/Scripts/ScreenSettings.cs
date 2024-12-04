using UnityEngine;
using UnityEngine.UI; // Per accedere agli elementi UI

public class ScreenSettings : MonoBehaviour
{
    public Image background; // L'elemento UI dello sfondo
    public Text statusText; // Per mostrare il messaggio

    // Cambia il colore in chiaro
    public void SetLightMode()
    {
        if (background != null)
        {
            background.color = new Color(120f / 255f, 135f / 255f,253f / 255f); // Blu chiaro
        }
        if (statusText != null)
        {
            statusText.text = "Modalità chiara attiva";
        }
    }

    // Cambia il colore in scuro
    public void SetDarkMode()
    {
        if (background != null)
        {
            background.color = new Color(19f / 255f, 24f / 255f, 63f / 255f); // Blu scuro
        }
        if (statusText != null)
        {
            statusText.text = "Modalità scura attiva";
        }
    }
}

