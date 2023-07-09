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
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime));
     
        rb.MovePosition(transform.right * moveSpeed);
    }


}
