using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidRocks : MonoBehaviour
{
    private float dir = 1;

    //Move the boat out of the way of rocks/other boats
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock") || collision.CompareTag("Boat"))
        {
            Turn();
        }
    }
    public void Turn()
    {
        //Flips if ship will go left or right
        //Putting this in when mines spawn so everytime it drops a mine it has a chance to swap its direction when coming near a rock
        if (Random.Range(0, 9) > 4)
        {
            dir = 1;
        }
        else dir = -1;
        GetComponentInParent<Transform>().Rotate(Vector3.forward * 50 * dir * Time.deltaTime);
    }
}
