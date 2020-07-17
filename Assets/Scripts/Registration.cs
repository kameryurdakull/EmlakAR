using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Registration : MonoBehaviour
{
    public InputField adField;
    public InputField kullaniciadiField;
    public InputField parolaField;
    public InputField emailField;
    
    public Button kaydolButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("ad", adField.text);
        form.AddField("parola", parolaField.text);
        form.AddField("kullaniciadi",kullaniciadiField.text);
        form.AddField("email", emailField.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("Kullanıcı başarıyla oluşturuldu.");
            SceneManager.LoadScene("Login");
            DBManager.name = adField.text;
        }
        else
        {
            Debug.Log("Kullanıcı oluşturulamadı. Hata #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        kaydolButton.interactable = (adField.text.Length >= 3 && parolaField.text.Length >= 6 && kullaniciadiField.text.Length >=3 && emailField.text.Length>=15);
    }
}
