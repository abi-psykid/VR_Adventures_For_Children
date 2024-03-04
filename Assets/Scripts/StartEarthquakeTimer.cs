using SojaExiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEarthquakeTimer : ObjectController
{

    private float gazeTimer = 0;
    public float GazeTime = 2;
    private bool gazeStatus;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }


    private void Update()
    {
        if (gazeStatus)
        {
            gazeTimer += Time.deltaTime;
        }

        if (gazeTimer >= GazeTime)
        {
            btnn();
        
        }
        
    }

    public new void OnPointerEnter()
    {
        gazeStatus = true;
    }

    public new void OnPointerExit()
    {
        gazeStatus = false;
        gazeTimer = 0;
    }

    public void btnn()
    {
        Debug.Log("Yahhoo!!!");
    }
    // Update is called once per frame
}
