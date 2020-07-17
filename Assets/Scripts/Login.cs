using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    
    public InputField kullaniciadiField;
    public InputField parolaField;
    

    public Button girisyapButton;

    public void CallLogin()
    {
        StartCoroutine(LoginUser());
    }

    IEnumerator LoginUser()
    {
        WWWForm form = new WWWForm();
        
        form.AddField("parola", parolaField.text);
        form.AddField("kullaniciadi", kullaniciadiField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            
            DBManager.username = kullaniciadiField.text;
            DBManager.score = int.Parse(www.text.Split('\t')[1]);
            SceneManager.LoadScene("AR");
        }
        else
        {
            Debug.Log("Kullanıcı girişi başarısız. Hata #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        girisyapButton.interactable = (parolaField.text.Length >= 6 && kullaniciadiField.text.Length >= 3);
    }
}
