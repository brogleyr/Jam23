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
    public float closeRockDistance;
    public float farRockDistance;
    public float closeBoatDistance;
    public float farBoatDistance;

    //Rock Count
    public int MaxRocks;
    private int CurrentRocks = 0;

    //Boat Spawn Mechanism
    public int MaxBoats;
    private int CurrentBoats = 0;

    //Radius around rocks where no rocks can spawn
    public float spawnRadiusRock;
    public float spawnRadiusBoat;

    private int gameObjectFindCounter = 0;
    private Transform fishTransform;

    // Start is called before the first frame update
    void Start()
    {
        fishTransform = GameObject.Find("Fish").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObjectFindCounter <= 0) {
            CurrentRocks = GameObject.FindGameObjectsWithTag("Rock").Length;
            CurrentBoats = GameObject.FindGameObjectsWithTag("Boat").Length;
            gameObjectFindCounter = 60;
        }
        else {
            gameObjectFindCounter--;
        }

        while (CurrentRocks < MaxRocks) {
            if (spawnObject(rock, closeRockDistance, farRockDistance)) {
            }
            CurrentRocks++;
        }
        //UnityEngine.Debug.Log("Current spawn time: " + spawnTime);
        while (CurrentBoats < MaxBoats) {
            if (spawnObject(boat, closeBoatDistance, farBoatDistance)) {
            };
            CurrentBoats++;
        }

        
    }

    bool spawnObject(GameObject prefab, float minDistance, float maxDistance)
    {
        float spawnAngle = Random.Range(0, 2.0f * Mathf.PI);
        float spawnDistance = Random.Range(minDistance, maxDistance);
        Vector3 spawnPositionFishSpace = new Vector3(Mathf.Sin(spawnAngle)*spawnDistance, Mathf.Cos(spawnAngle)*spawnDistance, 0);
        Vector3 spawnPosition = fishTransform.position + spawnPositionFishSpace;
        Vector3 spawnRotation = new Vector3(0, 0, Random.Range(-180, 180));

        Collider2D spawnCollision = Physics2D.OverlapCircle(spawnPosition, spawnRadiusRock);
        if (spawnCollision == null)
        {
            Instantiate(prefab, spawnPosition, Quaternion.Euler(spawnRotation));
            return true;
        }
        return false;
    }
}
