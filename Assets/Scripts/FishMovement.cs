using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishMovement : MonoBehaviour
{

    public float turnSpeed = 1000;
    public float moveSpeed = 15;
    public float angleX;
    public float angleY;
    private Vector2 _movementInput;
    public Rigidbody2D rb;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /*
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    */
    private void FixedUpdate()
    {

    }
}
