using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{
    public GameObject popUpPanel; // Assign the UI panel to this field in the Inspector

    public void ShowInstructions(string instructionsText)
    {
        popUpPanel.SetActive(true); // Activate the pop-up panel
        Text textElement = popUpPanel.GetComponentInChildren<Text>(); // Get the Text component
        textElement.text = instructionsText; // Set the instructions text
    }

    public void CloseInstructions()
    {
        popUpPanel.SetActive(false); // Deactivate the pop-up panel
    }
}
