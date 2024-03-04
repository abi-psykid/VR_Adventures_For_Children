using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPositionFront : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3 (0.2f, -0.7f, 2f);

    private Canvas canvas;
    private Transform playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = player.transform;
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPosition != null)
        {
            Vector3 canvasPosition = playerPosition.position + playerPosition.TransformDirection(offset);
            canvas.transform.position = canvasPosition;
            canvas.transform.rotation = playerPosition.rotation;
        }
    }
}
