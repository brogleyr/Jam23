using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavyBoat : MonoBehaviour
{
    public float speed = 0;

    private float mineSpawnRate = 5;
    private float mineSpawnTime = 0;
    private float dir = 1;

    public GameObject SeaMine;

    private Shooter m_shoooter;
    // Start is called before the first frame update
    void Start()
    {
        m_shoooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {

        //Move the boat forward
        transform.position += transform.right * speed * Time.deltaTime;



        //Mine Spawner
        if (mineSpawnTime < mineSpawnRate)
        {
            mineSpawnTime += Time.deltaTime;
        }
        else
        {
            //can spawn mines are varying times, can just set to 0 if you want consistant mine drops
            mineSpawnTime = Random.Range(0, 3);
            m_shoooter.Shoot();

            //Flips if ship will go left or right
            //Putting this in when mines spawn so everytime it drops a mine it has a chance to swap its direction when coming near a rock
            if (Random.Range(0, 9) > 4)
            {
                dir = 1;
            }
            else dir = -1;
        }
    }


    //Move the boat out of the way of rocks/other boats
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock"))
        {
            transform.Rotate(Vector3.forward * 50* dir * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Boat")
        {
                //scoreManager.BoatCrash(transform);
                //animator.SetTrigger("BoatDestroyed");

            Destroy(gameObject, 1f);
        }
    }
}
