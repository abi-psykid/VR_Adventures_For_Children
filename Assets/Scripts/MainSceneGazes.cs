using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneGazes : MonoBehaviour
{

    public Transform Player;

    private float gazeTimer = 0;
    public float GazeTime = 2;
    private bool gazeStatus;


    public void Update()
    {
        if (gazeStatus)
        {
            gazeTimer += Time.deltaTime;
        }

        if (gazeTimer >= GazeTime)
        {
            float dist = Vector3.Distance(Player.position, transform.position);
            if(dist < 15)
            {
                if(gameObject.name.Equals("Car"))
                {
                    SceneManager.LoadScene("TrafficSafety");
                }
                else if(gameObject.name.Equals("Building"))
                {
                    SceneManager.LoadScene("Earthquake");
                }
                else if(gameObject.name.Equals("Extinguisher"))
                {
                    Debug.Log("extinguisher..");
                    SceneManager.LoadScene("Inferno");
                }
                else
                {
                    Debug.Log("None");
                }
            }
        }
    }

    public  void OnPointerEnter()
    {
        gazeStatus = true;
        Debug.Log("entered");
    }

    public  void OnPointerExit()
    {
        gazeStatus = false;
        gazeTimer = 0;
        Debug.Log("exited");
    }



    /*
    public float gazeDuration = 2.0f; // Adjust the duration for interaction
    private float gazeTimer;
    private bool isGazing = false;
    private GameObject currentGazeObject;

    private void Update()
    {
       Ray ray = new Ray(transform.position, (-1) * transform.right);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            Debug.Log(hit.collider.name);

        // Cast a ray to detect UI objects
        if (Physics.Raycast(ray, out hit))
        {
            if (!isGazing)
            {
                isGazing = true;
                currentGazeObject = hit.collider.gameObject;
                gazeTimer = 0f;
            }

            gazeTimer += Time.deltaTime;

            if (gazeTimer >= gazeDuration)
            {
                ExecuteEvents.Execute(currentGazeObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                if (hit.collider.name.Equals("Car"))
                {
                    Debug.Log("Focused on Car");
                }
                else if(hit.collider.name.Equals("Building"))
                {
                    Debug.Log("Focused on Building");
                }
                else if (hit.collider.name.Equals("Extinguisher"))
                {
                    Debug.Log("focused on extinguisher");
                }
                ResetGaze();
            }
        }
        else
        {
            ResetGaze();
        }
    }

    private void ResetGaze()
    {
        isGazing = false;
        currentGazeObject = null;
        gazeTimer = 0f;
    }*/


}
