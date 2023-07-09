using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMineScript : MonoBehaviour
{
    public int damage = 1000;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, Random.Range(-180, 180));
        //Start countdown until mine despwans
        StartCoroutine(Lifetime());

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
            other.gameObject.GetComponent<HP>().TakeDamage(damage, "A Navy Sea Mine");
            Destroy(this.gameObject);
        }

    }
}
