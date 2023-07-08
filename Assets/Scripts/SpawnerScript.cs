using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
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
    public float closeDistance = 60;
    public float farDistance = 300;
    // public float TopBoundry = 0;
    // public float BottomBoundry = 0;
    // public float RightBoundry = 0;
    // public float LeftBoundry = 0;

    //Rock Count
    public int MaxRocks = 30;
    private int CurrentRocks = 0;

    //Boat Spawn Mechanism
    public int MaxBoats = 100;
    private int CurrentBoats = 0;
    // public float spawnRate = 0;
    // private float spawnTime = 0;

    //Radius around rocks where no rocks can spawn
    public float spawnRadiusRock = 20;
    public float spawnRadiusBoat = 10;

    private int gameObjectFindCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObjectFindCounter <= 0) {
            CurrentRocks = GameObject.FindGameObjectsWithTag("Rock").Length;
            Debug.Log(CurrentRocks + " rocks found");
            gameObjectFindCounter = 60;
        }
        else {
            gameObjectFindCounter--;
        }

        while (CurrentRocks < MaxRocks)
        {
            spawnRock();
        }
        //UnityEngine.Debug.Log("Current spawn time: " + spawnTime);
        if (CurrentBoats < MaxBoats)
        {
            //spawnBoat();
        }

        
    }

    void spawnRock()
    {
        if (CurrentRocks < MaxRocks)
        {
            float spawnAngle = Random.Range(0, 2.0f * Mathf.PI);
            float spawnDistance = Random.Range(closeDistance, farDistance);
            Vector3 spawnPositionFishSpace = new Vector3(Mathf.Sin(spawnAngle)*spawnDistance, Mathf.Cos(spawnAngle)*spawnDistance, 0);
            Vector3 spawnPosition = GameObject.Find("Fish").transform.position + spawnPositionFishSpace;
            Vector3 spawnRotation = new Vector3(0, 0, Random.Range(-180, 180));

            Collider2D spawnCollision = Physics2D.OverlapCircle(spawnPosition, spawnRadiusRock);
            UnityEngine.Debug.Log("Trying to Spawn Rock " + CurrentRocks);
            if (spawnCollision == null)
            {
                Instantiate(rock, spawnPosition, Quaternion.Euler(spawnRotation));
                CurrentRocks++;
            }


        }
    }

    void spawnBoat()
    {
        // var position = new Vector3(Random.Range(LeftBoundry, RightBoundry), Random.Range(BottomBoundry, TopBoundry), 0);
        // var rot = new Vector3(0, 0, Random.Range(-180, 180));
        // Collider2D spawnCollision = Physics2D.OverlapCircle(position, spawnRadiusBoat);
        // if (spawnCollision == false)
        // {
        //     Instantiate(boat, position, Quaternion.Euler(rot));
        //     UnityEngine.Debug.Log("Spawning boat ");
        // }
    }

    
}
