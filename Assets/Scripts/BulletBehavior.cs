using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    //speed for bullets
    public float speed = 20;
    Rigidbody2D rb;
    public int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        //find the rigidbody attached to this object
        rb = this.GetComponent<Rigidbody2D>();
        //apply a forward vector to the bullet at a given speed
        rb.velocity = transform.up * speed;
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        //then say what you hit
        Debug.Log(other.name);
        if (other.gameObject.tag == "Rock")
        {
            //if the object has the rock tag destroy the bullet
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Fish")
        {
            other.gameObject.GetComponent<HP>().TakeDamage(damage);
            Destroy(gameObject);
        }
            
    }
}
