using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingKeys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool isPressed = false;

    // Update is called once per frame
    void Update()
    {
        getMouseInputs();

        getKeyboardInputs();
    }

    private void getMouseInputs() {
        //0 left , 1 right , 2 middle
        const int LEFT_MOUSE = 0;
        const int RIGHT_MOUSE = 1;
        const int MIDDLE_MOUSE = 2;

        if ( Input.GetMouseButtonDown( LEFT_MOUSE ) )              Debug.Log("Mouse "  + LEFT_MOUSE + " is down"); 
        if ( Input.GetMouseButton( LEFT_MOUSE ) && !isPressed ) {  Debug.Log("Mouse "  + LEFT_MOUSE + " is Hold"); isPressed = true;}
        if ( Input.GetMouseButtonUp( LEFT_MOUSE ) ) {              Debug.Log("Mouse "  + LEFT_MOUSE + " Released"); isPressed = false;}
    
    }

    private void getKeyboardInputs() {
        getKeyCodeInput(KeyCode.Space); //controllera soltanto su spazio
        getActionInput("Jump"); // controllera tutti i pulsanti che l'azione 'Jump' possiede
    }
    private void getKeyCodeInput(KeyCode keyCode) {
        if (Input.GetKeyDown(keyCode)) {
            Debug.Log("Using keycode -> pressed " + keyCode);
        }
    }
    private void getActionInput(string inputString) {
        if (Input.GetButtonDown(inputString)) {
            Debug.Log("Using keycode -> pressed " + inputString);
        }
    }

    //AXIS
    private void getAxis() {
        const string HORIZONTAL_AXIS = "Horizontal";
        const string VERTICAL_AXIS  = "Vertical";

        //Avranno un valore tra -1 a 1
        float horizontal    = Input.GetAxis( HORIZONTAL_AXIS );
        float vertical      = Input.GetAxis( VERTICAL_AXIS );


    }
}
