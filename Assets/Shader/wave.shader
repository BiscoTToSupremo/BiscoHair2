using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeWave : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private bool isSwiping = false;
    private float swipeSpeed = 5f;
    private float changeSceneHeight = 10f; // L'altezza a cui l'onda triggera il cambio scena

    // Riferimento alla camera per rilevare lo swipe
    private Camera mainCamera;

    // Variabili per tracciare il movimento dello swipe
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    void Start()
    {
        startPos = transform.position;
        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleSwipeMovement();
        CheckSwipeEnd();
    }

    void HandleSwipeMovement()
    {
        // Gestisci swipe
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                touchEndPos = touch.position;
                // Sposta l'onda su in base allo swipe
                float swipeDistance = touchEndPos.y - touchStartPos.y;
                float movement = swipeDistance * Time.deltaTime * swipeSpeed;

                // Movimento verticale dell'onda
                transform.position = new Vector3(startPos.x, startPos.y + movement, startPos.z);
            }
        }

        // Se l'onda raggiunge l'altezza desiderata, cambia scena
        if (transform.position.y >= changeSceneHeight)
        {
            ChangeScene();
        }
    }

    void CheckSwipeEnd()
    {
        if (transform.position.y >= changeSceneHeight)
        {
            // Se l'onda ha raggiunto l'altezza del cambio scena, cambia scena
            ChangeScene();
        }
    }

   // void ChangeScene()
    {
        // Cambia scena al termine dello swipe
//        SceneManager.LoadScene("LoginScene"); // Cambia con il nome della scena di login
    }
}
