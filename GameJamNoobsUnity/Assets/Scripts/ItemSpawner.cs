using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefab = new GameObject[8];
    public GameObject poisonPrefab;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (Mathf.Round(elapsedTime) > 0 && Mathf.Round(elapsedTime) % 3 == 0) {
            GameObject newItem = Instantiate(itemPrefab[0], this.transform.position, Quaternion.identity);
            Debug.Log("new item.  " + " elapsed time: " + elapsedTime + "   and rounded: " + Mathf.Round(elapsedTime));
            elapsedTime = 0f;
        }
    }
}
