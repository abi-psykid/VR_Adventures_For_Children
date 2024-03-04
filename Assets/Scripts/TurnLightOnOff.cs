using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightOnOff : ObjectController
{

    private float gazeTimer = 0;
    public float GazeTime = 2;
    private bool gazeStatus;

    public bool lightOn = true;
    public Transform Player;
    public Light light;

    void Start()
    {
        if(Player == null)
        {
            Player = GameObject.Find("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gazeStatus)
        {
            gazeTimer += Time.deltaTime;
        }

        if (gazeTimer >= GazeTime)
        {
            float dist = Vector3.Distance(Player.position, transform.position);
            if (dist < 20)
            {
                if(lightOn == false)
                {
                    light.enabled = true;
                    lightOn = true;
                    gazeTimer = 0;
                }
                else
                {
                    light.enabled = false;
                    lightOn = false;
                    gazeTimer = 0;
                }
                
            }
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
}
