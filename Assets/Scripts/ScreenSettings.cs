using UnityEngine;
using UnityEngine.UI;

public class ScreenSettings : MonoBehaviour
{
    public Image background; // Elemento UI dello sfondo
    public Text statusText; // Per mostrare il messaggio

    void Start()
    {
        // Applica il colore salvato all'avvio della scena
        LoadColor();
    }

    public void SetLightMode()
    {
        if (background != null)
        {
            background.color = new Color(120f / 255f, 135f / 255f, 253f / 255f); // Blu chiaro
        }
        if (statusText != null)
        {
            statusText.text = "Modalità chiara attiva";
        }
        SaveColor();
    }

    public void SetSystemMode()
    {
        if (background != null)
        {
            background.color = Color.black; // Colore nero
        }
        if (statusText != null)
        {
            statusText.text = "Modalità di sistema attiva";
        }
        SaveColor();
    }

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

    public void LoadColor()
    {
        // Controlla se esistono valori salvati nei PlayerPrefs
        if (PlayerPrefs.HasKey("Panel_R"))
        {
            float r = PlayerPrefs.GetFloat("Panel_R");
            float g = PlayerPrefs.GetFloat("Panel_G");
            float b = PlayerPrefs.GetFloat("Panel_B");
            float a = PlayerPrefs.GetFloat("Panel_A");

            // Applica il colore salvato allo sfondo
            background.color = new Color(r, g, b, a);
        }
    }
}


