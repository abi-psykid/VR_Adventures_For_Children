using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform FPcamera;
    public Transform cameraBody;
    public Transform PlayerBody;
    public float x;
    public float y;
    public float z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBody.transform.rotation = Quaternion.Euler(0, FPcamera.transform.rotation.eulerAngles.y, FPcamera.transform.rotation.eulerAngles.z);

        cameraBody.position = PlayerBody.position + new Vector3(x, y, z);
    }
}
