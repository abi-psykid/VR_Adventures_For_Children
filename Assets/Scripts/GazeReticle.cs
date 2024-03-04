using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GazeReticle : MonoBehaviour
{
    public float gazeDuration = 2.0f; // Adjust the duration for interaction
    private float gazeTimer;
    private bool isGazing = false;
    private GameObject currentGazeObject;

    private void Update()
    {
        Ray ray = new Ray(transform.position, (-1)*transform.right);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            Debug.Log(hit.collider.name);

        // Cast a ray to detect UI objects
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.GetComponent<Button>())
        {
            if (!isGazing)
            {
                isGazing = true;
                currentGazeObject = hit.collider.gameObject;
                gazeTimer = 0f;
            }

            gazeTimer += Time.deltaTime;

            if (gazeTimer >= gazeDuration)
            {
                ExecuteEvents.Execute(currentGazeObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                ResetGaze();
            }
        }
        else
        {
            ResetGaze();
        }
    }

    private void ResetGaze()
    {
        isGazing = false;
        currentGazeObject = null;
        gazeTimer = 0f;
    }
}



/*public Canvas canvas;
    private GraphicRaycaster graphicRaycaster;
    private EventSystem eventSystem;

    private float gazeDuration = 2.0f; // Adjust the gaze duration
    private float gazeTimer;
    private GameObject currentGazeObject;

    private void Start()
    { 
        graphicRaycaster = canvas.GetComponent<GraphicRaycaster>(); // Find the Graphic Raycaster in the scene
        eventSystem = EventSystem.current; // Reference to the Event System
        //Debug.Log(graphicRaycaster);
    }

    private void Update()
    {
        CastRayAndInteract();
    }

    private void CastRayAndInteract()
    {
        Ray ray = new Ray(transform.position, new Vector3(-1, 0, 0)); // Cast a ray from the sphere

        PointerEventData pointerEventData = new PointerEventData(eventSystem);

        List<RaycastResult> results = new List<RaycastResult>();

        // Perform the raycast
        graphicRaycaster.Raycast(pointerEventData, results);

        foreach (RaycastResult result in results)
        {
            Debug.Log("Hit " + result.gameObject.name);
        }

        if (results.Count > 0)
        {
            Debug.Log(results[0].gameObject);
            GameObject hitObject = results[0].gameObject; // The first object in the list

            if (currentGazeObject != hitObject)
            {
                currentGazeObject = hitObject;
                gazeTimer = 0f;
            }
            else
            {
                gazeTimer += Time.deltaTime;
                if (gazeTimer >= gazeDuration)
                {
                    Button button = hitObject.GetComponent<Button>();
                    if (button != null)
                    {
                        button.onClick.Invoke(); // Invoke a function when the button is gazed at for the specified duration
                    }
                }
            }
        }
        else
        {
            currentGazeObject = null;
            gazeTimer = 0f;
        }
    }*/