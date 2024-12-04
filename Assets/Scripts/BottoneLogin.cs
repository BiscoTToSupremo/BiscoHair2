using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserLoginController : MonoBehaviour
{
    // Riferimenti ai campi della UI
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
   
    public TMP_Text errorText;

    public void OnLoginButtonClicked()
    {
        string username = usernameField.text;
        string password = passwordField.text;
       

        // Validazione dei dati
        if (string.IsNullOrEmpty(username)||string.IsNullOrEmpty(password))
        {
            DisplayError("Tutti i campi sono obbligatori.");
            return;
        }

        

       

        if (password.Length < 8)
        {
            DisplayError("Password Errata");
            return;
        }

        // Registrazione riuscita
        SaveUserData(username, password);
        DisplayError("Login completato!", true); // true per messaggi di successo
    }

    private void DisplayError(string message, bool success = false)
    {
        errorText.text = message;
        errorText.color = success ? Color.green : Color.red;
    }

    private void SaveUserData(string username,string password)
    {
        // Simulazione di salvataggio dei dati (locale o server)
        Debug.Log($"Utente convalidato: {username}");
        // Integrazione con un sistema di backend se necessario
    }
}

