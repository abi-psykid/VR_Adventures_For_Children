using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 150f;
    Vector3 initialPosition;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            Debug.Log("Collided!");
            Instantiate(prefab, initialPosition, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
