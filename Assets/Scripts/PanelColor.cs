using UnityEngine;
using UnityEngine.UI;

public class LoadPanelColor : MonoBehaviour
{
    public Image panelImage; // Riferimento al componente Image del Panel

    void Start()
    {
        if (panelImage == null)
        {
            panelImage = GetComponent<Image>();
        }

        LoadColor();
    }

    private void LoadColor()
    {
        // Controlla se i dati colore esistono nei PlayerPrefs
        if (PlayerPrefs.HasKey("Panel_R"))
        {
            float r = PlayerPrefs.GetFloat("Panel_R");
            float g = PlayerPrefs.GetFloat("Panel_G");
            float b = PlayerPrefs.GetFloat("Panel_B");
            float a = PlayerPrefs.GetFloat("Panel_A");

            Color loadedColor = new Color(r, g, b, a);
            panelImage.color = loadedColor;

            Debug.Log("Colore caricato: " + loadedColor);
        }
       
        
          
    
    }
}
