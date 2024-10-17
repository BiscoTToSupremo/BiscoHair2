using UnityEngine;
using UnityEngine.UI;

public class ScrollRawImage : MonoBehaviour
{
    public RawImage rawImage;    // La Raw Image da muovere
    public float speed = 0.1f;   // Velocità del movimento

    private Rect uvRect;         // Rettangolo UV della texture

    void Start()
    {
        uvRect = rawImage.uvRect;
    }

    void Update()
    {
        // Aggiorna la posizione UV della texture per creare l'effetto di scorrimento laterale
        uvRect.x += speed * Time.deltaTime;

        // Applica l'aggiornamento alla Raw Image
        rawImage.uvRect = uvRect;
    }
}