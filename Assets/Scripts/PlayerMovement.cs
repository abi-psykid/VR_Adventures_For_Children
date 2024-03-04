using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public CharacterController characterController;
    public float speed = 2f;
    public float rotationSpeed = 90.0f;
    private float rotationAmount = 0f;
    public float gravity = -9.18f;
    public float Gravity = 9.18f;
    public float velocity = 0f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
       
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            //animator.SetTrigger("Walk");
            characterController.Move(move * speed * Time.deltaTime);
            rotationAmount = x * rotationSpeed * Time.deltaTime;
            characterController.transform.Rotate(Vector3.up * rotationAmount);
        }
        else
        {
            rotationAmount = 0f;
        }
        //controller.Move(move * speed * Time.deltaTime);
        

        if (characterController.isGrounded)
        {
            velocity = 0;
            velocity -= Gravity * Time.deltaTime;
        }
        else
        {
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.root.tag.ToString());
        if (collision.transform.root.CompareTag("Sidewalk"))
        {
            Debug.Log("Sidewalk");
        }
    }*/
}
