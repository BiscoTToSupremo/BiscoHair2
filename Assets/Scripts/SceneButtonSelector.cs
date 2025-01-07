using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwipeSceneSelector : MonoBehaviour
{
    public ScrollRect scrollRect; // Collegare la Scroll View
    public Button[] sceneButtons; // Pulsanti delle scene
    private int currentIndex = 0;

    private float swipeThreshold = 0.5f; // Valore per considerare uno swipe valido

    

    public void LoadCurrentScene()
    {
        // Carica la scena selezionata
        string sceneName = sceneButtons[currentIndex].name; // Usa il nome del pulsante
        SceneManager.LoadScene(sceneName);
    }
}
