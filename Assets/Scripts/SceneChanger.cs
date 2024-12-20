using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Metodo per caricare la scena delle Impostazioni
    public void LoadSettingsScene()
    {
        // Salva il nome della scena corrente come "scena precedente"
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);

        // Cambia la scena a "Impostazioni"
        SceneManager.LoadScene("Impostazioni");
    }

    // Metodo per tornare alla scena precedente
    public void LoadPreviousScene()
    {
        // Recupera il nome della scena precedente dai PlayerPrefs
        string previousScene = PlayerPrefs.GetString("PreviousScene", "");

        // Se è stato salvato un nome di scena, cambiala
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.LogWarning("Nessuna scena precedente salvata!");
        }
    }
}
