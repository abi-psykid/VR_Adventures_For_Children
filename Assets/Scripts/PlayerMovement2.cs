using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField]
    private Transform FPCamera;

    [SerializeField]
    private float toggleAngle = 30f;

    [SerializeField]
    private float speed = 30f;

    [SerializeField]
    private bool moveForward = false;

    private CharacterController characterController;

    public float gravity = -15f;

    Vector3 velocity;

    bool isGrounded, isStanding = true;

    public bool angleMove = false;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();        
    }

    // Update is called once per frame
    void Update()
    {

        // Character Movement - Angles

        if(angleMove)
        {
            if (FPCamera.eulerAngles.x >= toggleAngle && FPCamera.eulerAngles.x < 90.0f)
            {
                moveForward = true;
            }
            else
            {
                moveForward = false;
            }

            if (moveForward)
            {
                Vector3 v_forward = FPCamera.TransformDirection(Vector3.forward);
                characterController.SimpleMove(v_forward * speed);
            }
        }


        // Character Movement - Input Keys
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
        


        // Sit down
        /*
        if(Input.GetKey(KeyCode.C))
        {
            if(isStanding)
            {
                characterController.height = 1f;
                isStanding = false;
            }
            else
            {
                characterController.height = 2.8f;
                isStanding= true;
            }
        }
        */

    }
}
