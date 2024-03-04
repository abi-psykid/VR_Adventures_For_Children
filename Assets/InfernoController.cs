using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfernoController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject extinguisherOnWall;
    public GameObject extinguisherInHand;
    public GameObject player;
    public GameObject wildfire;
    private Vector3 changeInFire;
    void Start()
    {
        // wildfire.GetComponent<ParticleSystem>().scalingMode = ParticleSystemScalingMode.Shape;
        wildfire.transform.localScale = new Vector3(0.2f,1f,0.2f);
        changeInFire = new Vector3(0.002f, 0f, 0.002f);
        extinguisherOnWall.SetActive(true);
        extinguisherInHand.SetActive(false);
        wildfire.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        wildfire.transform.localScale += changeInFire;

        if (wildfire.transform.localScale.x <= 0.1f && extinguisherInHand.activeSelf)
        {
            wildfire.SetActive(false);
        }
    }

    public void pickupExtinguisher()
    {
        changeInFire -= new Vector3(0.004f, 0, 0.004f);
        extinguisherOnWall.SetActive(false);
        extinguisherInHand.SetActive(true);
    }
}
