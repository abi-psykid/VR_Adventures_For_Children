using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChummaCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Inside collider");
        if (collision.gameObject.CompareTag("Respawn")) // "Player" collides with the boundary
        {
            showInfo();
        }
    }

    private void showInfo()
    {
        Debug.Log("Dishoom!");
    }
}
