using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydarFish : MonoBehaviour
{
    //What is the camera following
    public Transform target;
    //How smooth will it follow it
    public float smoothSpeed = 0.125f;
    //The difference between the starting camera's start and the players start so it can maintain it
    private Vector3 offset;
    public float turnSpeed = 500;
    // Start is called before the first frame update
    void Start()
    {
        
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime);
        //rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime));
    }
}
