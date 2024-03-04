using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareHeadMovement : MonoBehaviour
{
    public GameObject body;

    public float speed = 10f;
    public float rotationSpeed = 90.0f;
    private float rotationAmount = 0f;
    private bool isWalking = false;
    private Vector3 movement;
    private Vector3 direction;

    private Rigidbody rb;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if ((rb = this.GetComponent<Rigidbody>()) == null)
            rb = body.GetComponent<Rigidbody>();
        animator = rb.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        direction = new Vector3 (moveInput, 0, rotationInput);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            //animator.SetTrigger("Walk");
            movement = transform.forward * moveInput;
            rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;
        } else
        {
            movement = transform.forward * 0;
            rotationAmount = 0f;
        }
    }

    void FixedUpdate()
    {
        moveCharacter(movement, rotationAmount);
        animate(direction);
    }

    private void moveCharacter(Vector3 direction, float rotation)
    {
        rb.velocity = direction.normalized * speed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.up * rotation);
    }

    private void animate(Vector3 direction)
    {
        isWalking = (direction.x > 0.1f || direction.x < -0.1f) || (direction.z > 0.1f || direction.z < -0.1f) ? true : false;
        animator.SetBool("isWalking", isWalking);
    }
}
