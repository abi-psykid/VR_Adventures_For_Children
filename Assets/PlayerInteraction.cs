using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject player;
    public InfernoController controller;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // print("hmm");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            print("player colliding");
        else print("something");

        controller.pickupExtinguisher();
    }
}
