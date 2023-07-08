using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float turnSpeed = 1000;
    public float moveSpeed = 15;
    public float movementX;
    public float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void onMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {

        Vector2 movement = new Vector2();
        rb.AddForce(movement * moveSpeed);

        /*
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime));
        rb.MovePosition(rb.position + ((Vector2)transform.right * moveSpeed * Time.deltaTime));
        Camera.main.transform.position =new Vector3(transform.position.x,transform.position.y, -10);
        */
    }
}
