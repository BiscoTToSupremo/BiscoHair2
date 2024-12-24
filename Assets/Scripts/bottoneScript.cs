using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Necessario per lavorare con il Button e il Text

public class bottoneScript : MonoBehaviour
{
    public string Scena2 = "Scena2";  // Aggiungi questa variabile per specificare la scena da caricare

    void Start()
    {
        // Crea un nuovo GameObject per il pulsante
        GameObject buttonObject = new GameObject("MyButton");

        // Aggiungi un componente Button
        Button button = buttonObject.AddComponent<Button>();

        // Aggiungi un componente RectTransform
        RectTransform rectTransform = buttonObject.GetComponent<RectTransform>();
        rectTransform.SetParent(GameObject.Find("Canvas").transform); // Assicurati che la Canvas esista

        // Imposta la posizione e la dimensione del pulsante
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(160, 30); // Dimensione del pulsante

        // Crea un GameObject per il testo
        GameObject buttonTextObject = new GameObject("ButtonText");
        buttonTextObject.transform.SetParent(buttonObject.transform);

        // Aggiungi un componente Text
        Text buttonText = buttonTextObject.AddComponent<Text>();
        buttonText.text = "Cliccami!";  // Testo del pulsante
        buttonText.alignment = TextAnchor.MiddleCenter;

        // Imposta il font e la dimensione del testo
        buttonText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        buttonText.fontSize = 14;

        // Aggiungi il componente Image al pulsante
        Image buttonImage = buttonObject.AddComponent<Image>();
        buttonImage.color = Color.cyan;  // Colore di sfondo del pulsante

        // Aggiungi il listener per l'evento di clic
        button.onClick.AddListener(() => ChangeScene());  // Richiama ChangeScene quando il pulsante viene cliccato
    }

    // Metodo per cambiare scena
    public void ChangeScene()
    {
        SceneManager.LoadScene(Scena2);  // Carica la scena specificata in Scena2
    }

    void Update()
    {
        // Codice aggiornamento, se necessario
    }
}
