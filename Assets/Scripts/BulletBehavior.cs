using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    //Speed for bullets
    public float speed = 20;
    Rigidbody2D rb;
    //Damage the bullet does
    public int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        //Find the rigidbody attached to this object
        rb = this.GetComponent<Rigidbody2D>();
        //Apply a forward vector to the bullet at a given speed
        rb.velocity = transform.right * speed;
        //Start countdown until bulletdespawn
        StartCoroutine(Lifetime());
    }
    //Despawn after 15 seconds if doesn't hit anything
    IEnumerator Lifetime() 
    {
        yield return new WaitForSeconds(15);
        Destroy(this.gameObject);

    }
    //when the trigger finds a fish or rock destroy the bullet and attempt to deal damage
    void OnTriggerEnter2D(Collider2D other)
    {
        //then say what you hit
        Debug.Log(other.name);
        //If you hit a rock
        if (other.gameObject.tag == "Rock")
        {
            //if the object has the rock tag destroy the bullet
            Destroy(gameObject);
        }
        //If you hit the player
        else if(other.gameObject.CompareTag("Fish"))
        {
            other.gameObject.GetComponent<HP>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
            
    }
}
