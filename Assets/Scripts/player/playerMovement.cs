using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    private Vector2 movementDir;
    public int playerSpeed;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(movementDir != Vector2.zero)
        {
            rb.velocity = new Vector2(movementDir.x * playerSpeed * Time.deltaTime, movementDir.y * playerSpeed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void Mover(InputAction.CallbackContext context)
    {
        movementDir = context.action.ReadValue<Vector2>();
    }

}
