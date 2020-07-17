using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleApi : MonoBehaviour
{
    public RawImage img;
    

    string url;
    public float lat;
    public float lon;
    
    LocationInfo li;

    public int zoom = 14;
    public int mapWidth = 640;
    public int mapHeight = 640;
    public Texture texture;

    public enum mapType {roadmap,satellite,hybrid,terrain}
    public mapType mapSelected;
    public int scale;

    public void GetTexture(string url, Action<Texture> onSuccess)
    {
        StartCoroutine(LoadTexture(url, onSuccess));
    }

    private IEnumerator LoadTexture(string url, Action<Texture> onSuccess)
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
           "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
           + "&maptype=" + mapSelected +
           "&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyCoWFHZbnrz0CA9EZU_S0st-LtS4eeFfTI";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            onSuccess?.Invoke(((DownloadHandlerTexture)www.downloadHandler).texture);
        }
    }
    private void OnSuccess(Texture texture)
    {
        img.texture = texture;
    }



    /*IEnumerator Map()
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
            + "&maptype=" + mapSelected +
            "&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyCoWFHZbnrz0CA9EZU_S0st-LtS4eeFfTI";
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www;
       
        
        //img.texture = www.texture;
        //img.SetNativeSize();
        
    }


    void Start()
    {
        img = gameObject.GetComponent<RawImage>();
        
        StartCoroutine(Map());
    }*/

}
