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
    public float closeDistance;
    public float farDistance;
    // public float TopBoundry = 0;
    // public float BottomBoundry = 0;
    // public float RightBoundry = 0;
    // public float LeftBoundry = 0;

    //Rock Count
    public int MaxRocks;
    private int CurrentRocks = 0;

    //Boat Spawn Mechanism
    public int MaxBoats;
    private int CurrentBoats = 0;
    // public float spawnRate = 0;
    // private float spawnTime = 0;

    //Radius around rocks where no rocks can spawn
    public float spawnRadiusRock;
    public float spawnRadiusBoat;

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
            CurrentBoats = GameObject.FindGameObjectsWithTag("Boat").Length;
            gameObjectFindCounter = 60;
        }
        else {
            gameObjectFindCounter--;
        }

        while (CurrentRocks < MaxRocks) {
            if (spawnObject(rock)) {
            }
            CurrentRocks++;
        }
        //UnityEngine.Debug.Log("Current spawn time: " + spawnTime);
        while (CurrentBoats < MaxBoats) {
            if (spawnObject(boat)) {
            };
            CurrentBoats++;
        }

        
    }

    bool spawnObject(GameObject prefab)
    {
        float spawnAngle = Random.Range(0, 2.0f * Mathf.PI);
        float spawnDistance = Random.Range(closeDistance, farDistance);
        Vector3 spawnPositionFishSpace = new Vector3(Mathf.Sin(spawnAngle)*spawnDistance, Mathf.Cos(spawnAngle)*spawnDistance, 0);
        Vector3 spawnPosition = GameObject.Find("Fish").transform.position + spawnPositionFishSpace;
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
