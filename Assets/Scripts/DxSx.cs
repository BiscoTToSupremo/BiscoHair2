using UnityEngine;
using UnityEngine.UI;

public class MoveRawImage : MonoBehaviour
{
    // Riferimento alla RawImage
    public RawImage rawImage;

    // Velocità di movimento, personalizzabile dall'Inspector
    public float speed = 1.0f;

    // Ampiezza del movimento a destra e a sinistra
    public float moveRange = 100f;

    // Variabile per tenere traccia della posizione iniziale
    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        // Memorizza la posizione iniziale della RawImage
        startPosition = rawImage.rectTransform.anchoredPosition;
    }

    void Update()
    {
        // Calcola la posizione corrente della RawImage
        Vector3 currentPosition = rawImage.rectTransform.anchoredPosition;

        // Muove la RawImage a destra o a sinistra
        if (movingRight)
        {
            currentPosition.x += speed * Time.deltaTime;
            if (currentPosition.x >= startPosition.x + moveRange)
            {
                movingRight = false;
            }
        }
        else
        {
            currentPosition.x -= speed * Time.deltaTime;
            if (currentPosition.x <= startPosition.x - moveRange)
            {
                movingRight = true;
            }
        }

        // Applica la nuova posizione alla RawImage
        rawImage.rectTransform.anchoredPosition = currentPosition;
    }
}