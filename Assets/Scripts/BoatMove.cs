using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    public float lineLength;
    public float lineStrength;
    public float reelSpeed;
    private bool attached = false;
    private Vector2 centerOfMass = new Vector2(-1.5f, 0);
    private Rigidbody2D rb;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = transform.GetChild(1).gameObject.GetComponent<Animator>();
        float lineAngle = Random.Range(0, Mathf.PI);
        Vector3 lineStartPosition = new Vector3(Mathf.Sin(lineAngle)*lineLength, Mathf.Cos(lineAngle)*lineLength, 0);
        transform.GetChild(0).position = transform.TransformPoint(lineStartPosition);
        //rb.centerOfMass = centerOfMass;
    }

    // Update is called once per frame
    void Update()
    {
        if (attached) {
            lineLength -= reelSpeed;
            if (lineLength <= 0) {
                Debug.Log("NOOO");
                Destroy(gameObject); // TODO make something happen 
            }
        }
    }

    private void FixedUpdate() {
        if (attached) {
            MoveFisherman();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Rock") {
            GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            manager.BoatCrash();
            Destroy(transform.GetChild(0).gameObject);
            attached = false;
            animator.SetTrigger("BoatDestroyed");
            Destroy(gameObject, 1f);
        }
    }

    void MoveFisherman() {
        // Vector3 lineVector = transform.GetChild(0).position - transform.position;
        // rb.AddForceAtPosition(lineVector * lineStrength, transform.position, ForceMode2D.Force);
        
        // if (lineVector.magnitude > lineLength) {
        //     rb.MovePosition(transform.GetChild(0).position - (lineVector.normalized * lineLength));
        // }

        Vector2 lineVector = transform.GetChild(0).position - transform.position; 
        if (lineVector.magnitude > lineLength) {
            Vector2 idealSpot = lineVector.normalized * lineLength;
            float distToIdealSpot = Vector2.Distance(idealSpot, transform.position);
            GetComponent<Rigidbody2D>().AddForceAtPosition(idealSpot.normalized * distToIdealSpot * lineStrength, transform.position, ForceMode2D.Force);
        }
    }

    public void SetAttached(bool attatchStatus) {
        attached = attatchStatus;
        animator.SetBool("BoatAttached", true);
    }
}
