using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefab = new GameObject[11];
    private float elapsedTime;
    private float spawnTarget, minSpawnTime, maxSpawnTime, baseMinSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        baseMinSpawnTime = 0.2f;
        minSpawnTime = 0.5f;
        maxSpawnTime = 3f;
    }

    // Update is called once per frame
    void Update() {

    }
    
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnTarget) {
            Vector3 spawnLocation = new Vector3 (14, Random.Range(-2f, 4f), 0);
            int spawnItemNum = Random.Range(0, itemPrefab.GetUpperBound(0)+1);
            GameObject newItem = Instantiate(itemPrefab[spawnItemNum], spawnLocation, Quaternion.identity);
            newItem.transform.parent = this.gameObject.transform;
            spawnTarget += Random.Range(minSpawnTime, maxSpawnTime);      // set next spawn time target

            maxSpawnTime *= .95f;        // slowly decrease maxSpawnTime to spawn more items as the game progresses
            minSpawnTime *= .98f;        // slowly decrease minSpawnTime to spawn more items as the game progresses
            minSpawnTime = minSpawnTime <= baseMinSpawnTime ? baseMinSpawnTime : minSpawnTime;    // no lower than .2f
            maxSpawnTime = maxSpawnTime <= minSpawnTime ? minSpawnTime : maxSpawnTime;
        }
    }
}
