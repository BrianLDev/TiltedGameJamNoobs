using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  // new unity namespace for consolidated input handling

public class PlayerController : MonoBehaviour
{
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
        if (movingUp) {
            rb2d.velocity += (Vector2.up * accel);
        }
        if (movingDown) {
            rb2d.velocity += (Vector2.down * accel);
        }
        else if (movingLeft) {
            rb2d.velocity += (Vector2.left * accel);
        }
        else if (movingRight) {
            rb2d.velocity += (Vector2.right * accel);
        }
    }
}
