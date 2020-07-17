
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]

public class AlphabetAR : MonoBehaviour
{
    private Object[] placedPrefabs;

    private Object[] placedPrefabsTR;

    private GameObject placedObject;

    private Vector2 touchPosition = default;

    private ARRaycastManager arRaycastManager;

    private Pose hitPose;

    private bool onTouchHold = false;

    private int count = 0;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        placedPrefabs = Resources.LoadAll<GameObject>("WeModels/Alphabet/ENG");
        placedPrefabsTR = Resources.LoadAll<GameObject>("WeModels/Alphabet/TR");
        //  placedPrefabs = placedPrefabs.OrderBy(n => n.name).ToArray();
        //    placedPrefabs = GameObject.FindGameObjectsWithTag("PlacedPrefabs").OrderBy(n => n.name).ToArray();
        //   placedPrefabs = placedPrefabs.OrderBy(< placedObject => placedObject.name).ToArray();
    }


    public void NextButton()
    {
        Destroy(placedObject);
        count++;
        if (SceneManager.GetActiveScene().name == "AlphabetAR")
        {
            if (count >= placedPrefabs.Length)
            {
                count = 0;
            }
            placedObject = Instantiate((GameObject)placedPrefabs[count], hitPose.position, hitPose.rotation);
            Debug.Log(count + "count");
            Debug.Log(placedObject + "placedObject");
        }
        else
        {
            if (count >= placedPrefabsTR.Length)
            {
                count = 0;
            }
            placedObject = Instantiate((GameObject)placedPrefabsTR[count], hitPose.position, hitPose.rotation);
        }
            //     placedObject = Instantiate((GameObject)placedPrefabs[count], hitPose.position, Quaternion.AngleAxis(180, Vector3.up));
            Debug.Log(placedObject + "placedObject");
            Debug.Log(count + "count");
        } 


    public void PreviousButton()
    {
        Destroy(placedObject);
        if (SceneManager.GetActiveScene().name == "AlphabetAR")
        {
            count--;
            if (count < 0)
            {
                count = placedPrefabs.Length;
            }
            placedObject = Instantiate((GameObject)placedPrefabs[count], hitPose.position, hitPose.rotation);
        }
        else
        {
            count--;
            if (count < 0)
            {
                count = placedPrefabsTR.Length - 1;
            }
            placedObject = Instantiate((GameObject)placedPrefabsTR[count], hitPose.position, hitPose.rotation);
            //      placedObject = Instantiate((GameObject)placedPrefabs[count], hitPose.position, Quaternion.AngleAxis(180, Vector3.up));
            Debug.Log(count);
        } }

    bool IsPointerOverUIObject(Vector2 pos)
    {
        if (EventSystem.current == null)
            return false;
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject))
                {
                    onTouchHold = true;

                }
            }
            if (touch.phase == TouchPhase.Ended)
            {

                onTouchHold = false;

            }
        }

        if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon) && !IsPointerOverUIObject(touchPosition))
        {
            hitPose = hits[0].pose;
            if (placedObject == null)
            {
                if (SceneManager.GetActiveScene().name == "AlphabetAR")
                {
                    placedObject = Instantiate((GameObject)placedPrefabs[count], hitPose.position, hitPose.rotation);
                    Debug.Log(count + "count");
                    Debug.Log(placedObject + "placedObject");
                }
                else
                    placedObject = Instantiate((GameObject)placedPrefabsTR[count], hitPose.position, hitPose.rotation);
            }
            else
            {
                if (onTouchHold)
                {
                    placedObject.transform.position = hitPose.position;
                    placedObject.transform.rotation = hitPose.rotation;
                }

            }
        }
    }
}
