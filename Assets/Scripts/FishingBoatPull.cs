using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBoatPull : MonoBehaviour
{
    public float lineLength;
    public float lineStrength;
    public float reelSpeed;
    private bool attached = false;
    private Vector2 centerOfMass = new Vector2(-1.5f, 0);
    private Rigidbody2D rb;
    private Animator animator;
    private ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = transform.GetChild(1).gameObject.GetComponent<Animator>();
        float lineAngle = Random.Range(0, Mathf.PI);
        Vector3 lineStartPosition = new Vector3(Mathf.Sin(lineAngle)*(lineLength - 1), Mathf.Cos(lineAngle)*lineLength, 0);

        Collider2D lineSpawnCollision = Physics2D.OverlapCircle(lineStartPosition, 1);
        if (lineSpawnCollision != null && lineSpawnCollision.tag == "Rock") {
            lineAngle += Mathf.PI;
            lineStartPosition = new Vector3(Mathf.Sin(lineAngle)*(lineLength - 1), Mathf.Cos(lineAngle)*lineLength, 0);
        }

        transform.GetChild(0).position = transform.TransformPoint(lineStartPosition);
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (attached) {
            lineLength -= reelSpeed;
            if (lineLength <= 0) {
                Debug.Log("NOOO");
                //scoreManager.OffTheLine();
                Destroy(gameObject); // TODO make something happen 
            }
        }
    }


    private void FixedUpdate() {
        if (attached) {
            PullBoatByLine();
        }
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Rock" && attached) {
            Destroy(transform.GetChild(0).gameObject);
            attached = false;
            GetComponent<Scuttle>().ScuttleBoat();
        }
        
        if (other.gameObject.tag == "HostileBoat" && attached) {
            Destroy(transform.GetChild(0).gameObject);
            attached = false;
            if (other.gameObject.GetComponent<Scuttle>() != null) {
                other.gameObject.GetComponent<Scuttle>().ScuttleBoat();
            }
            else {
                other.transform.parent.GetComponent<Scuttle>().ScuttleBoat();
            }
            GetComponent<Scuttle>().ScuttleBoat();
        }
    }


    void PullBoatByLine() {

        Vector2 lineVector = transform.GetChild(0).position - transform.position; 
        if (lineVector.magnitude > lineLength) {
            Vector2 idealSpot = lineVector.normalized * lineLength;
            GetComponent<Rigidbody2D>().AddForceAtPosition(idealSpot * lineStrength, transform.position, ForceMode2D.Force);
        }
    }


    public void SetAttached(bool attatchStatus) 
    {
        attached = attatchStatus;
        animator.SetBool("BoatAttached", true);
    }

    public bool GetAttached() {
        return attached;
    }
}
