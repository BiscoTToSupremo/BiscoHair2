using UnityEngine;
using TMPro;  // Necessario per TextMeshPro

public class LanguageManager : MonoBehaviour
{
    public TextMeshProUGUI[] textsToTranslate; // Array di testi da tradurre
    public string[] italianTexts; // Testi in italiano
    public string[] englishTexts; // Testi in inglese

    private int currentLanguage = 0; // 0 = Italiano, 1 = Inglese

    // Metodo per impostare la lingua italiana
    public void SetItalianLanguage()
    {
        currentLanguage = 0; // Italiano
        UpdateTexts();
        Debug.Log("Lingua impostata su Italiano");
    }

    // Metodo per impostare la lingua inglese
    public void SetEnglishLanguage()
    {
        currentLanguage = 1; // Inglese
        UpdateTexts();
        Debug.Log("Lingua impostata su Inglese");
    }

    // Metodo per aggiornare tutti i testi in base alla lingua corrente
    private void UpdateTexts()
    {
        for (int i = 0; i < textsToTranslate.Length; i++)
        {
            if (currentLanguage == 0 && i < italianTexts.Length)
            {
                textsToTranslate[i].text = italianTexts[i];
            }
            else if (currentLanguage == 1 && i < englishTexts.Length)
            {
                textsToTranslate[i].text = englishTexts[i];
            }
        }
    }
}

