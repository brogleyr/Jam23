using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NavyBoat : MonoBehaviour
{
    public float speed = 0;

    private float mineSpawnRate = 5;
    private float mineSpawnTime = 0;
    private float dir = 1;

    public GameObject SeaMine;
    // Start is called before the first frame update
    void Start()
    {

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
            spawnMine();

            //Flips if ship will go left or right
            //Putting this in when mines spawn so everytime it drops a mine it has a chance to swap its direction when coming near a rock
            if (Random.Range(0, 9) > 5)
            {
                dir = 1;
            }
            else dir = -1;
        }
    }
    void spawnMine()
    {
        Vector3 spawnRotation = new Vector3(0, 0, Random.Range(-180, 180));
        Vector3 spawnPosition = transform.position + (transform.right * -3);
        Instantiate(SeaMine, spawnPosition, Quaternion.Euler(spawnRotation));
    }

    //Move the boat out of the way of rocks/other boats
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock"))
        {
            transform.Rotate(Vector3.forward * 50* dir * Time.deltaTime);
        }
    }
}
