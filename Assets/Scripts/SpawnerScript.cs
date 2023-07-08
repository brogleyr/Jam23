using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SpawnerScript : MonoBehaviour
{
    //Object to spawn
    public GameObject rock;
    public GameObject boat;

    //Spawn Boundries
    public float TopBoundry = 0;
    public float BottomBoundry = 0;
    public float RightBoundry = 0;
    public float LeftBoundry = 0;

    //Rock Count
    public float MaxRocks = 0;
    private float CurrentRocks = 0;

    //Boat Spawn Mechanism
    public float spawnRate = 0;
    private float spawnTime = 0;

    //Radius around rocks where no rocks can spawn
    public float spawnRadiusRock = 0;
    public float spawnRadiusBoat = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentRocks < MaxRocks)
        {
            spawnRocks();
        }
        //UnityEngine.Debug.Log("Current spawn time: " + spawnTime);
        if (spawnTime < spawnRate)
        {
            spawnTime += Time.deltaTime;
        }
        else
        {
            spawnTime = 0;
            spawnBoat();
        }

        
    }

    void spawnRocks()
    {
        if (CurrentRocks < MaxRocks)
        {
            var position = new Vector3(Random.Range(LeftBoundry, RightBoundry), Random.Range(BottomBoundry, TopBoundry), 0);
            var rot = new Vector3(0, 0, Random.Range(-180, 180));
            Collider2D spawnCollision = Physics2D.OverlapCircle(position, spawnRadiusRock);
            UnityEngine.Debug.Log("Trying to Spawn Rock " + CurrentRocks);
            if (spawnCollision == false)
            {
                Instantiate(rock, position, Quaternion.Euler(rot));
                CurrentRocks++;
                UnityEngine.Debug.Log("Spawning Rock " + CurrentRocks);
            }


        }
    }

    void spawnBoat()
    {
        var position = new Vector3(Random.Range(LeftBoundry, RightBoundry), Random.Range(BottomBoundry, TopBoundry), 0);
        var rot = new Vector3(0, 0, Random.Range(-180, 180));
        Collider2D spawnCollision = Physics2D.OverlapCircle(position, spawnRadiusBoat);
        if (spawnCollision == false)
        {
            Instantiate(boat, position, Quaternion.Euler(rot));
            UnityEngine.Debug.Log("Spawning boat ");
        }
    }

    
}
