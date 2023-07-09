using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavyBoat : MonoBehaviour
{
    public float speed = 6;

    private float mineSpawnRate;
    private float mineSpawnTime = 0;
    private Shooter m_shoooter;
    private AvoidRocks m_avoidRocks;
    // Start is called before the first frame update
    void Start()
    {

        m_shoooter = GetComponent<Shooter>();
        m_avoidRocks = GetComponentsInChildren<AvoidRocks>()[0];
        mineSpawnRate = 1/m_shoooter.rateOfFire;
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
                m_avoidRocks.Turn();
            }
        }
    }
}
