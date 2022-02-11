using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public Texture2D cursor;
    public Texture2D cursorClicked;

    private CursorControls controls;


    private void Awake()
    {
        //intitalize the input system
        controls = new CursorControls();

        ChangeCursor(cursor);

        //keep the game cursor confined to the game screen
        Cursor.lockState = CursorLockMode.Confined;
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

    }

    private void StartedClick()
    {
        ChangeCursor(cursor);
    }

    private void EndedClick()
    {
        ChangeCursor(cursorClicked);
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
