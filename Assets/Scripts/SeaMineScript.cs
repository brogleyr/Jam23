using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMineScript : MonoBehaviour
{
    public int damage = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Start countdown until mine despwans
        StartCoroutine(Lifetime());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Despawn after 15 seconds if doesn't hit anything
    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(15);
        Destroy(this.gameObject);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //If the player goes over a mine trigger damage
        if (other.gameObject.CompareTag("Fish"))
        {
            other.gameObject.GetComponent<HP>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

    }
}
