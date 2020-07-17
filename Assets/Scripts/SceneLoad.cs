using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    public Text userDisplay;
    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            userDisplay.text = "Hoşgeldin " + DBManager.username;
        }
    }
    public void LoadRegister()
    {
        SceneManager.LoadScene("Reg");
    }
    public void LoadLogin()
    {
        SceneManager.LoadScene("Login");
    }
    public void LoadCity()
    {
        SceneManager.LoadScene("City");
    }
    public void Location()
    {
        SceneManager.LoadScene("Location");
    }
    public void sListele()
    {
        SceneManager.LoadScene("sListele");
    }
    public void kListele()
    {
        SceneManager.LoadScene("kListele");
    }
    public void pListele()
    {
        SceneManager.LoadScene("pListele");
    }
    public void ARk1()
    {
        SceneManager.LoadScene("ARk1");
    }
    public void ARk2()
    {
        SceneManager.LoadScene("ARk2");
    }
    public void ARs()
    {
        SceneManager.LoadScene("ARs");
    }
    public void City()
    {
        SceneManager.LoadScene("City");
    }
}
