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
    private Vector3 mousePos;
    private Vector3 worldPosition;
    private Vector3 target;
    public Rigidbody2D rb;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    private void Update()
    {
        /*
        Vector3 mousePos = Mouse.current.position.ReadValue();
        angleX = Mouse.current.position.ReadValue().x;
        angleY = Mouse.current.position.ReadValue().y;

        Vector3 target = (angleX, angleY, 0);
        transform.LookAt(target);
        */
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        transform.LookAt(worldPosition);

    }
    
    private void FixedUpdate()
    {

    }
}
