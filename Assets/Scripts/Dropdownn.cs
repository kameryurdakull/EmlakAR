using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class Dropdownn : MonoBehaviour
{
   
    public Dropdown dd;
    public Dropdown dd2;
    public Dropdown dd3;
    
    public Button btn;

    List<string> il = new List<string>() { "İl Seçiniz", "İstanbul", "Ankara", "İzmir", "Mersin" };
    List<string> istanbul = new List<string>() { "İlçe Seçiniz", "Kadıköy", "Beyoğlu", "Beşiktaş" };
    List<string> ankara = new List<string>() { "İlçe Seçiniz", "Çankaya", "Etimesgut", "Mamak" };
    List<string> izmir = new List<string>() { "İlçe Seçiniz", "Bornova", "Çeşme", "Buca" };
    List<string> mersin = new List<string>() { "İlçe Seçiniz", "Pozcu", "Mezitli", "Erdemli" };
    List<string> mezitli = new List<string>() { "Mahalle Seçiniz", "Atatürk", "Cumhuriyet", "Deniz" };
    List<string> erdemli = new List<string>() { "Mahalle Seçiniz", "Alata", "Akdeniz", "Arpaçbahşiş", "Kargıpınarı" };

    void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {
        dd.AddOptions(il);
    }
    public void SehirSec()
    {
        if (dd.value == 1)
        {
            dd2.ClearOptions();
            dd2.AddOptions(istanbul);
            Debug.Log("İstanbulun İlçeleri");
        }
        if (dd.value == 2)
        {
            dd2.ClearOptions();
            dd2.AddOptions(ankara);
            Debug.Log("Ankaranın İlçeleri");
        }
        if (dd.value == 3)
        {
            dd2.ClearOptions();
            dd2.AddOptions(izmir);
            Debug.Log("İzmirin İlçeleri");
        }
        if (dd.value == 4)
        {
            dd2.ClearOptions();
            dd2.AddOptions(mersin);
            Debug.Log("Mersinin İlçeleri");
        }



    }
    public void IlceSec()
    {
        if (dd2.value == 2)
        {
            
            dd3.ClearOptions();
            dd3.AddOptions(mezitli);
            
            Debug.Log("Mezitlinin Mahalleleri");
        }
        if (dd2.value == 3)
        {
            dd3.ClearOptions();
            dd3.AddOptions(erdemli);
            Debug.Log("Erdemlinin Mahalleleri");
        }
    }

    /*public void MahalleSec()
    {
        if (dd3.value == 0)
        {
            SceneManager.LoadScene("Listele");
        }
    }*/
    public void Update()
    {

            if (dd3.value != 0)
            {

                btn.gameObject.SetActive(true);
                
            }
        
    }
  
}