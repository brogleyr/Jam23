using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisherman : MonoBehaviour
{
    public float lineLength = 5;
    public float lineStrength = 1;
    private bool attached = false;
    private Vector2 centerOfMass = new Vector2(-1.5f, 0);
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.centerOfMass = centerOfMass;
    }

    // Update is called once per frame
    void Update()
    {
        if (attached) {
            MoveFisherman();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Rock") {
            GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            manager.BoatCrash(gameObject);
        }
    }

    void MoveFisherman() {
        Vector2 lineVector = transform.GetChild(0).position - transform.position; 
        if (lineVector.magnitude > lineLength) {
            Vector2 idealSpot = lineVector.normalized * lineLength;
            GetComponent<Rigidbody2D>().AddForceAtPosition(idealSpot * lineStrength, transform.position, ForceMode2D.Force);
        }
    }

    public void SetAttached(bool attatchStatus) {
        attached = attatchStatus;
    }
}
