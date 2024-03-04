using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public GameObject popUpUI;
    public Canvas canvas;

    private Transform playerPosition;
    public Vector3 offset = new Vector3(0.2f, -0.7f, 2f);


    private void Start()
    {
        playerPosition = gameObject.transform.root;
    }

    private void PopUpUIPosition()
    {
        if (playerPosition != null) {
            Vector3 canvasPosition = playerPosition.position + playerPosition.TransformDirection(offset);
            canvas.transform.position = canvasPosition;
            canvas.transform.rotation = playerPosition.rotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Exit")) // "Player" exits scene
        {
            goToHome();
        }
        if (collision.gameObject.CompareTag("Road")) // "Player" collides with the boundary
        {
            //ShowPopUpUI("CAREFULL!");
            PopUpUIPosition();
            Debug.Log("Collision!");
            ShowPopUpUI("red", "DANGER!!!\nCross on Zebra Crossing!");
        }
        if (collision.gameObject.CompareTag("Car")) // "Player" collides with the boundary
        {
            //ShowPopUpUI("CAREFULL!");
            PopUpUIPosition();
            Debug.Log("Collision!");
            ShowPopUpUI("red", "DANGER!!!\nLook both sides before crossing!");
            HidePopUpUI();
            ShowPopUpUI("red", "GAME OVER!");
            Invoke("goToHome", 3f);
        }
    
    }

    void goToHome()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road")) // "Player" collides with the boundary
        {
            //ShowPopUpUI("CAREFULL!");
            Debug.Log("Collision Over!");
            HidePopUpUI();
        }
        if (collision.gameObject.CompareTag("Car")) // "Player" collides with the boundary
        {
            //ShowPopUpUI("CAREFULL!");
            Debug.Log("Collision Over!");
            HidePopUpUI();
        }

    }

    private void ShowPopUpUI(string colour, string instructionsText)
    {
        if (popUpUI != null)
        { 
            popUpUI.SetActive(true);

            Image img = popUpUI.GetComponent<Image>();
            img.color = (colour == "red") ? Color.red : Color.blue;
            //TMP_Text txt = TextField.GetComponent<TMP_Text>();
            //txt.text = instructionsText;
            TMP_Text txt = popUpUI.GetComponentInChildren<TMP_Text>();
            txt.text = instructionsText;
        }
    }

    private void HidePopUpUI()
    {
        if (popUpUI != null)
        {
            popUpUI.SetActive(false);
        }
    }
}
