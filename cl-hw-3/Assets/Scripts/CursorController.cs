using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{

    public Texture2D cursor;
    public Texture2D cursorClicked;

    private CursorControls controls;

    private Camera mainCamera;

    public GameObject target;

    public GameObject decoyOne;


    public GameObject highScore;
    private Text scoreText;

    private int currentScore;




    private void Awake()
    {
        //intitalize the input system
        controls = new CursorControls();

        ChangeCursor(cursor);

        //keep the game cursor confined to the game screen
        Cursor.lockState = CursorLockMode.Confined;

        mainCamera = Camera.main;

    }

    //this function is called when the object becomes enabled and active
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    // Start is called before the first frame update
    private void Start()
    {
        //adding the action map
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();

        //get the high score text component;
        scoreText = highScore.GetComponent<Text>();
    }

    private void StartedClick()
    {
        ChangeCursor(cursor);
    }

    private void EndedClick()
    {
        ChangeCursor(cursorClicked);
        DetectObject();
    }


    public void DetectObject()
    {
        //create a ray cast that goes out from the mouse
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        
        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
                
        if (hits2D.collider.tag == "Target")
        {
            //if target is hit change the position
            TargetPosition();
            DecoyPosition();
            currentScore += 1;
            scoreText.text = currentScore.ToString();
            
        }
        else if (hits2D.collider.tag == "Decoy")
        {
            //if the decoy is hit, remove the dots and end the game
            RemoveDots();
            Debug.Log("GAME OVER");
        }
    }

    void TargetPosition()
    {
        //change target position
        float xRandom = Random.Range(-8, 8);
        float yRandom = Random.Range(-4, 4);
        target.transform.position = new Vector3(xRandom, yRandom, 0);
    }

    void DecoyPosition()
    {
        //change decoy position
        float xRandom = Random.Range(-8, 8);
        float yRandom = Random.Range(-4, 4);
        decoyOne.transform.position = new Vector3(xRandom, yRandom, 0);
    }

    void RemoveDots()
    {
        //move the dots off screen
        target.transform.position = new Vector3(100,100, 100);
        decoyOne.transform.position = new Vector3(100,100,100);
    }




    //change the cursor texure method
    private void ChangeCursor(Texture2D cursorType)
  
    {
        //the hotspot is where on the cursor texture hits
        //below code makes the hotspot in the center of the texture
        Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);

        //SetCursor lets you add in a custom cursor
        //Requires a texture, the hotspot, and how it is rendered (hardware/software)
        Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }

}
