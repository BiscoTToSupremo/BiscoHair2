using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserRegistrationController : MonoBehaviour
{
    // Riferimenti ai campi della UI
    public TMP_InputField usernameField;
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public TMP_InputField confirmPasswordField;
    public TMP_Text errorText;

    public void OnRegisterButtonClicked()
    {
        string username = usernameField.text;
        string email = emailField.text;
        string password = passwordField.text;
        string confirmPassword = confirmPasswordField.text;

        // Validazione dei dati
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
        {
            DisplayError("Tutti i campi sono obbligatori.");
            return;
        }

        if (!email.Contains("@"))
        {
            DisplayError("Inserire un'email valida.");
            return;
        }

        if (password != confirmPassword)
        {
            DisplayError("Le password non corrispondono.");
            return;
        }

        if (password.Length < 6)
        {
            DisplayError("La password deve contenere almeno 6 caratteri.");
            return;
        }

        // Registrazione riuscita
        SaveUserData(username, email, password);
        DisplayError("Registrazione completata!", true); // true per messaggi di successo
    }

    private void DisplayError(string message, bool success = false)
    {
        errorText.text = message;
        errorText.color = success ? Color.green : Color.red;
    }

    private void SaveUserData(string username, string email, string password)
    {
        // Simulazione di salvataggio dei dati (locale o server)
        Debug.Log($"Utente registrato: {username}, {email}");
        // Integrazione con un sistema di backend se necessario
    }
}

