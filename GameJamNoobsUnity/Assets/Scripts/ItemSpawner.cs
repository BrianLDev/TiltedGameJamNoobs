using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefab = new GameObject[9];
    private float elapsedTime;
    private float spawnTime = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnTime) {
            Vector3 spawnLocation = new Vector3 (14, Random.Range(-2f, 4f), 0);
            int spawnItemNum = Random.Range(0, 9);
            GameObject newItem = Instantiate(itemPrefab[spawnItemNum], spawnLocation, Quaternion.identity);
            Debug.Log("new item.  " + " elapsed time: " + elapsedTime + "   and rounded: " + Mathf.Round(elapsedTime));
            spawnTime += Random.Range(0.2f, 2.5f);
        }
    }
}
