using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

        if (username != PlayerPrefs.GetString("Username", "N/A") || password != PlayerPrefs.GetString("Password", "N/A"))
        {
            DisplayError("Credenziali Errate.");
            return;
        }
            else
            {
                LoadUserData();
            }
        
       

        if (password.Length < 8)
        {
            DisplayError("Password Errata");
            return;
        }

        // Registrazione riuscita
        
        DisplayError("Login completato!", true); // true per messaggi di successo
    }

    private void DisplayError(string message, bool success = false)
    {
        errorText.text = message;
        errorText.color = success ? Color.green : Color.red;
    }

    public void LoadUserData()
    {
        string username = PlayerPrefs.GetString("Username", "N/A");
        string email = PlayerPrefs.GetString("Email", "N/A");
        string password = PlayerPrefs.GetString("Password", "N/A");
        SceneManager.LoadScene("AnteprimaVideo");

        Debug.Log($"Username: {username}, Email: {email}, Password: {password}");
    }

 
}

