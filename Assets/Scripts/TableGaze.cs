using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableGaze : MonoBehaviour
{
    public Transform Player;

    public CharacterController characterController;

    public Material outlineMaterial;
    private Material initialMaterial;

    private float gazeTimer = 0;
    public float GazeTime = 2;
    private bool gazeStatus;
    private bool isStanding = true;

    // Start is called before the first frame update
    void Start()
    {
        initialMaterial = GetComponent<Renderer>().material;
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
            if(Player != null && characterController != null) 
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 15)
                {
                    if (isStanding)
                    {
                        StartCoroutine(sitting());
                    }
                    else
                    {
                        StartCoroutine(standing());
                    }
                }
            }
        }
    }

    IEnumerator sitting()
    {
        characterController.height = 1f;
        print("sitting");
        isStanding = false;
        gazeTimer = 0;
        GazeTime = 7f;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator standing()
    {
        characterController.height = 2.8f;
        print("standing");
        isStanding = true;
        gazeTimer = 0;
        GazeTime = 2f;
        yield return new WaitForSeconds(.5f);
    }

    public void OnPointerEnter()
    {
        gameObject.GetComponent<Renderer>().material = outlineMaterial;
        gazeStatus = true;
    }

    public void OnPointerExit()
    {
        gameObject.GetComponent<Renderer>().material = initialMaterial;
        gazeStatus = false;
        gazeTimer = 0;
    }
}
