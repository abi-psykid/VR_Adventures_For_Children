using SojaExiles;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class CameraShaker : MonoBehaviour
{
    //#region variables
    public bool camShakeActive = true;
    public GameObject MainDoor;
    public GameObject WarningMessage;

    public TMP_Text ResultUI;

    public Transform ComputerTableGround;

    private opencloseDoor door;
    private bool opened = false;

    private bool warning_showing = false;

    [Range(0, 1)]
    [SerializeField] float trauma;
    [SerializeField] float traumaMultiplier = 5f;
    [SerializeField] float traumaMangitude = 0.8f;
    
    float timeCounter;
    float waitForEarthquake;
    float earthquakeTime;

    //#endregion


    void Start()
    {
        door = MainDoor.GetComponent<opencloseDoor>();
        waitForEarthquake = Random.Range(10f, 30f);
        waitForEarthquake = 20f;
        earthquakeTime = waitForEarthquake + 20f;
        print("Earthquake Timer = " + waitForEarthquake);
    }

    //#region accessors
    public float Trauma
    {
        get { return trauma; }
        set { trauma = Mathf.Clamp01(value); } 
    }
    //#endregion

    //#region methods
    float GetFloat(float seed)
    {
        return (Mathf.PerlinNoise(seed, timeCounter)  - 0.5f) * 2 ;
    }

    Vector3 GetVec3()
    {
        return new Vector3(GetFloat(1), GetFloat(10), 0);
    }

    void Update()
    {
        if (camShakeActive)
        {
            timeCounter += Time.deltaTime * trauma * traumaMultiplier;
            Vector3 newPos = GetVec3() * traumaMangitude;
            transform.localPosition = newPos;

            float dist = Vector3.Distance(ComputerTableGround.position, transform.position);
            if (dist < 1)
            {
                warning_showing = false;
            } else
            {
                warning_showing = true;
            }
        }

        if (door.open == true && opened == false)
        {
            opened = true;
            Invoke("start_earthquake", waitForEarthquake);
            Invoke("stop_earthquake", earthquakeTime);
        }

        //if(Vector3.Distance(.position, transform.position))

    }


    private void FixedUpdate()
    {
        if (camShakeActive)
        {
            float dist = Vector3.Distance(ComputerTableGround.position, transform.position);
            if(dist < 0.8)
            {
                warning_showing = false;
                print("under the table...");
            }
        }
    }



    void start_earthquake()
    {
        Debug.Log("entered earthquake");
        camShakeActive = true;
        warning_showing = true;
        InvokeRepeating("enableWarning", 0f, 2f);
        // Display Warning
    }

    void stop_earthquake()
    {
        camShakeActive = false;
        warning_showing = false;
        CancelInvoke();

        disableWarning();

        float dist = Vector3.Distance(ComputerTableGround.position, transform.position);

        Debug.Log(dist);
        if (dist < 1.2)
        {
            print("alive");
            ResultUI.text = "Survived!";
            ResultUI.color = Color.green;

        }
        else
        {
            print("Dead");
            ResultUI.text = "Game Over!";
            ResultUI.color = Color.red;
        }

        Invoke("goToHome", 5f);  

    }

    void enableWarning()
    {
        Debug.Log(warning_showing);
        if(warning_showing)
        {
            WarningMessage.SetActive(true);
            Invoke("disableWarning", 1f);
        }

    }

    void goToHome()
    {
        Debug.Log("Should go to home screen");
        SceneManager.LoadScene("MainScene");
    }

    void disableWarning()
    {
        WarningMessage.SetActive(false);   
    }
    //#endregion
}
