using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwipeSceneSelector : MonoBehaviour
{
    public ScrollRect scrollRect; // Collegare la Scroll View
    public Button[] sceneButtons; // Pulsanti delle scene
    public float swipeThreshold = 0.2f; // Valore per considerare uno swipe valido (0.2 = 20% dello schermo)
    public float smoothTime = 0.2f; // Tempo di smorzamento per lo scorrimento

    private int currentIndex = 0; // Indice della scena corrente
    private Vector2 startPos; // Posizione iniziale del tocco
    private bool isSwiping = false; // Flag per rilevare se è in corso uno swipe
    private float targetHorizontalPosition; // Posizione orizzontale target della ScrollView
    private float scrollVelocity; // Velocità di scorrimento per SmoothDamp

    private void Start()
    {
        // Imposta la posizione iniziale della ScrollView
        if (sceneButtons.Length > 0)
        {
            targetHorizontalPosition = GetButtonPosition(currentIndex);
            scrollRect.horizontalNormalizedPosition = targetHorizontalPosition;
        }

        // Aggiungi listener ai pulsanti per caricare le scene
        for (int i = 0; i < sceneButtons.Length; i++)
        {
            int index = i; // Copia l'indice per il listener
            sceneButtons[i].onClick.AddListener(() => LoadScene(index));
        }
    }

    private void Update()
    {
        // Gestione dello swipe
        HandleSwipeInput();

        // Smorzamento dello scorrimento
        scrollRect.horizontalNormalizedPosition = Mathf.SmoothDamp(
            scrollRect.horizontalNormalizedPosition,
            targetHorizontalPosition,
            ref scrollVelocity,
            smoothTime
        );
    }

    private void HandleSwipeInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Inizia lo swipe
            startPos = Input.mousePosition;
            isSwiping = true;
        }
        else if (Input.GetMouseButtonUp(0) && isSwiping)
        {
            // Fine dello swipe
            Vector2 endPos = Input.mousePosition;
            Vector2 swipeDelta = endPos - startPos;

            if (Mathf.Abs(swipeDelta.x) > Screen.width * swipeThreshold)
            {
                // Swipe a destra o sinistra
                if (swipeDelta.x > 0 && currentIndex > 0)
                {
                    // Swipe a destra
                    currentIndex--;
                }
                else if (swipeDelta.x < 0 && currentIndex < sceneButtons.Length - 1)
                {
                    // Swipe a sinistra
                    currentIndex++;
                }

                // Aggiorna la posizione target della ScrollView
                targetHorizontalPosition = GetButtonPosition(currentIndex);
            }

            isSwiping = false;
        }
    }

    private float GetButtonPosition(int index)
    {
        // Calcola la posizione normalizzata (0-1) del pulsante nella ScrollView
        return (float)index / (sceneButtons.Length - 1);
    }

    public void LoadScene(int index)
    {
        // Carica la scena selezionata
        if (index >= 0 && index < sceneButtons.Length)
        {
            string sceneName = sceneButtons[index].name; // Usa il nome del pulsante
            SceneManager.LoadScene(sceneName);
        }
    }
}