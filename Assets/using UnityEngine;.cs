using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Android;

public class SceneSwitcher : MonoBehaviour
{
    // Bottone che cambia la scena
    public Button yourButton;

    void Start()
    {
        // Aggiungi un listener per il bottone
        yourButton.onClick.AddListener(OnButtonClick);
    }

    // Funzione che viene chiamata quando si clicca il bottone
    int i=0;
    void OnButtonClick()
    {
        // Controlla se hai il permesso per usare la fotocamera
        if (Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            // Se il permesso è già concesso, avvia la fotocamera
            OpenFrontCamera();
        }
        else
        {
            // Chiedi il permesso per usare la fotocamera
            Permission.RequestUserPermission(Permission.Camera);
            i++;
            if (i==2)
            {
                Console.WriteLine("Il permesso non è stato concesso.");
            }
            else
            {
                void OnButtonClick();

            }
            
        }

    }

    // Funzione per aprire la fotocamera anteriore
    void OpenFrontCamera()
    {
        // Logica per attivare la fotocamera anteriore (questa logica dipende dal tuo sistema)
        // Su dispositivi Android, Unity non ha una API di fotocamera di default. Potresti aver bisogno di usare un plugin
        // o un pacchetto come "Unity AR Foundation" per gestire la fotocamera.
        
        Debug.Log("Fotocamera anteriore aperta!");
    }
}