using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fish : MonoBehaviour
{

    public Rigidbody2D rb;
    public float turnSpeed;
    public float moveSpeed;
    public float baseMoveSpeed;
    public float speedGrowthFactor = 1;
    public float topSpeed = 50f;
    public float boundingSpeed = 500f;
    public float baseScale = 1;
    public float scaleGrowthFactor = 0.06f;
    public float topScale = 5;
    
    private ScoreManager scoreManager;
    private GameManager gameManager;

    void Start() {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update() {
        if (moveSpeed > boundingSpeed) {
            gameManager.Transcend();
        }
    }
    
    void FixedUpdate()
    {
        //moveSpeed = Mathf.Min(baseMoveSpeed + (speedGrowthFactor * scoreManager.GetCombo()), topSpeed);
        //float newScale = Mathf.Min(baseScale + (scaleGrowthFactor * scoreManager.GetCombo()), topScale);
        if (!gameManager.gameIsOver)
        {
            moveSpeed = baseMoveSpeed + (speedGrowthFactor * scoreManager.GetCombo());

            float newScale = baseScale + (scaleGrowthFactor * scoreManager.GetCombo());

            transform.localScale = new Vector3(newScale, newScale, newScale);

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - transform.position;
            float angle = Vector2.SignedAngle(Vector2.right, direction);
            Vector3 targetRotation = new Vector3(0, 0, angle);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime));
            rb.MovePosition(rb.position + ((Vector2)transform.right * moveSpeed * Time.deltaTime));
            //Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        }
    }
    public void Disable(bool Dead)
    {
        if (Dead == true)
        {
            GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
    }

}
