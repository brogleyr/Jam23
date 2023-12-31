using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    //What is the camera following
    Transform target;
    //How smooth will it follow it
    public float smoothSpeed = 0.125f;
    //The difference between the starting camera's start and the players start so it can maintain it
    private Vector3 offset;
    Camera cam;
    float zoom;
    public float zoomToSpeedRatio = 0.1f;
    private GameManager m_gameManager;
    private void Start()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        target = GameObject.Find("Fish").GetComponent<Transform>();
        offset = transform.position - target.transform.GetChild(2).position;
        cam = GetComponent<Camera>();
        zoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!m_gameManager.gameIsOver)
        {
            cam.orthographicSize = zoom + ((target.GetComponent<Fish>().moveSpeed * zoomToSpeedRatio) * (1 * zoomToSpeedRatio) - 5);
            Vector3 desiredPosition = target.transform.GetChild(2).position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = desiredPosition;
        }
        
    }
}
