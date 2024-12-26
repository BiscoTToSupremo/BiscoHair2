using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwipeSceneSelector : MonoBehaviour
{
    public ScrollRect scrollRect; // Collegare la Scroll View
    public Button[] sceneButtons; // Pulsanti delle scene
    private int currentIndex = 0;

    private float swipeThreshold = 0.5f; // Valore per considerare uno swipe valido

    void Update()
    {
        // Controlla lo swipe laterale
        if (Input.GetMouseButtonUp(0)) // Rileva il rilascio del dito o clic
        {
            float normalizedPosition = scrollRect.horizontalNormalizedPosition;

            if (normalizedPosition < currentIndex - swipeThreshold)
            {
                currentIndex = Mathf.Clamp(currentIndex + 1, 0, sceneButtons.Length - 1);
            }
            else if (normalizedPosition > currentIndex + swipeThreshold)
            {
                currentIndex = Mathf.Clamp(currentIndex - 1, 0, sceneButtons.Length - 1);
            }

            // Sposta al pulsante corretto
            scrollRect.horizontalNormalizedPosition = (float)currentIndex / (sceneButtons.Length - 1);
        }
    }

    public void LoadCurrentScene()
    {
        // Carica la scena selezionata
        string sceneName = sceneButtons[currentIndex].name; // Usa il nome del pulsante
        SceneManager.LoadScene(sceneName);
    }
}
