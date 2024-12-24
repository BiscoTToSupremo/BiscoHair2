using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SwipeUpControl : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public RectTransform swipeObject; // Oggetto da trascinare
    public float maxHeight = 400f;    // Altezza massima per lo swipe
    public string nextSceneName = "NextScene"; // Nome della scena successiva

    private Vector2 startPosition;    // Posizione iniziale dello swipe object

    void Start()
    {
        // Salva la posizione iniziale dello swipe object
        startPosition = swipeObject.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Calcola la nuova posizione trascinata
        Vector2 newPosition = swipeObject.anchoredPosition + new Vector2(0, eventData.delta.y);

        // Clampa la posizione tra il punto iniziale e l'altezza massima
        newPosition.y = Mathf.Clamp(newPosition.y, startPosition.y, startPosition.y + maxHeight);
        swipeObject.anchoredPosition = newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Se la posizione massima è stata raggiunta, cambia scena
        if (swipeObject.anchoredPosition.y >= startPosition.y + maxHeight)
        {
            ChangeScene();
        }
        else
        {
            // Torna alla posizione iniziale
            swipeObject.anchoredPosition = startPosition;
        }
    }

    private void ChangeScene()
    {
        // Cambia la scena con il nome specificato
        SceneManager.LoadScene(nextSceneName);
    }
}
