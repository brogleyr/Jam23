using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AvoidRocks : MonoBehaviour
{
    private float dir = 1;
    private float timer = 0;

    //Move the boat out of the way of rocks/other boats
    private void OnTriggerStay2D(Collider2D collision)
    {
        timer += Time.deltaTime;
        if (collision.CompareTag("Rock") || collision.CompareTag("Boat"))
        {
            Turn();
        }
    }
    public void Turn()
    {
        if(timer > 5)
        {
            //Flips if ship will go left or right
            if (Random.Range(0, 9) > 4)
            {
                dir = 1;
            }
            else dir = -1;
        }
        if (transform.parent != null) {
            transform.parent.Rotate(Vector3.forward * 50 * dir * Time.deltaTime);
        }
    }
}
