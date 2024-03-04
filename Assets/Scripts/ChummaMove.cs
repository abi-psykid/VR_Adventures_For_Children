using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChummaMove : MonoBehaviour
{
    public float speed = 100f;
    public float rotationSpeed = 90.0f;
    private float rotationAmount = 0f;

    private Vector3 movement;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            //animator.SetTrigger("Walk");
            movement = transform.forward * moveInput;
            rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;
        }
        else
        {
            movement = transform.forward * 0;
            rotationAmount = 0f;
        }
    }

    void FixedUpdate()
    {
        moveCharacter(movement, rotationAmount);
    }

    private void moveCharacter(Vector3 direction, float rotation)
    {
        rb.velocity = direction.normalized * speed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.up * rotation);
    }

    
}
