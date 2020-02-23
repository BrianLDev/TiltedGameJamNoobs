using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner instance = null;  // public instance of this GameManager that all scripts can access (singleton)
    public GameObject[] itemPrefab = new GameObject[11];
    private float elapsedTime;
    private float spawnTarget, minSpawnTime, maxSpawnTime, baseMinSpawnTime;

    void Awake() {
        if (instance == null)   // Check if instance already exists
            instance = this;    // if not, set instance to this

        else if (instance != this)  // If instance already exists and it's not this:
            // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);    

        // TODO: replace this with events once I figure out how they work in Unity
        GameManager.instance.gameState = GameManager.GameState.PlayingGame; // since ItemSpawner is only on the 01-Main level, will only spawn items then
    }

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
        if (GameManager.instance.gameState == GameManager.GameState.PlayingGame) {
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
    
}
