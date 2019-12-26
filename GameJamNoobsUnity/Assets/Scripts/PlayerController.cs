using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  // new unity namespace for consolidated input handling

public class PlayerController : MonoBehaviour
{
    // MyPlayerControls is the C# class that Unity generated.
    // It encapsulates the data from the .inputactions asset we created
    // and automatically looks up all the maps and actions for us.
    // MyPlayerControls controls;

    public float accel = 2f;
    public float drag = 0.2f;    

    private Rigidbody2D rb2d;
    private bool movingUp, movingDown, movingLeft, movingRight = false;

    // Start is called before the first frame update
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.zero;
        rb2d.drag = drag;
    }

    public void OnUse(InputAction.CallbackContext context) {
        // 'Use' code here.
        Debug.Log(context);
    }

    public void OnMove(InputAction.CallbackContext context) {
        // 'Move' code here.
        Debug.Log(context);
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.W) ) {  movingUp = true;  }
        if (Input.GetKeyDown(KeyCode.S) ) {  movingDown = true;  }
        if (Input.GetKeyDown(KeyCode.A) ) {  movingLeft = true;  }
        if (Input.GetKeyDown(KeyCode.D) ) {  movingRight = true;  }

        if (Input.GetKeyUp(KeyCode.W) ) {  movingUp = false;  }
        if (Input.GetKeyUp(KeyCode.S) ) {  movingDown = false;  }
        if (Input.GetKeyUp(KeyCode.A) ) {  movingLeft = false;  }
        if (Input.GetKeyUp(KeyCode.D) ) {  movingRight = false;  }
    }

    void FixedUpdate()
    {
        var gamepad = Gamepad.current;

        if (gamepad == null)
            return;     // no gamepad connected

        if (gamepad.rightTrigger.wasPressedThisFrame) {
            // 'Use' code here
        }

        Vector2 move = gamepad.leftStick.ReadValue();
        // 'Move' code here

        if (movingUp) {
            Debug.Log("Up");
            rb2d.velocity += (Vector2.up * accel);
        }
        if (movingDown) {
            Debug.Log("Down");
            rb2d.velocity += (Vector2.down * accel);
        }
        else if (movingLeft) {
            Debug.Log("Left");
            rb2d.velocity += (Vector2.left * accel);
        }
        else if (movingRight) {
            Debug.Log("Right");
            rb2d.velocity += (Vector2.right * accel);
        }
    }
}
