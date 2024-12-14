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
        SaveColor();
    }
    // Cambia il colore in nero
    public void SetSystemMode()
    {
        if (background != null)
        { 
            background.color = Color.black; // Colore nero
        }
        if (statusText != null)
        {
            statusText.text = "Modalità di sistema attiva"; // Messaggio di stato
        }
        SaveColor();
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
        SaveColor();
    }

    public void SaveColor()
    {
        // Salva i componenti RGBA del colore nei PlayerPrefs
        Color panelColor = background.color;
        PlayerPrefs.SetFloat("Panel_R", panelColor.r);
        PlayerPrefs.SetFloat("Panel_G", panelColor.g);
        PlayerPrefs.SetFloat("Panel_B", panelColor.b);
        PlayerPrefs.SetFloat("Panel_A", panelColor.a);
        PlayerPrefs.Save();
    }
    }


