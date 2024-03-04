using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;

public class TrackedMovement : MonoBehaviour
{
    public Transform amera;
    public float toggleAngle = 30.0f;
    public float speed = 3.0f;
    public bool moveForward;
    private bool isWalking = false;

    private CharacterController characterController;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (amera.eulerAngles.x >= toggleAngle && amera.eulerAngles.x < 90.0f ) {
            moveForward = true;
            isWalking = true;
        } else
        {
            moveForward= false;
            isWalking = false;
        }

        if (moveForward)
        {
            Vector3 forward = amera.TransformDirection(Vector3.forward);

            characterController.SimpleMove(forward * speed);
        }
    }

    private void FixedUpdate()
    {
        animate();
    }

    private void animate()
    {
        animator.SetBool("isWalking", isWalking);
    }
}
