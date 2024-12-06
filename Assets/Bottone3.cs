using UnityEngine;
using UnityEngine.SceneManagement; // Necessario per gestire le scene

public class Bottone3 : MonoBehaviour
{
    // Nome della scena da caricare

    // Metodo chiamato al clic del pulsante
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
