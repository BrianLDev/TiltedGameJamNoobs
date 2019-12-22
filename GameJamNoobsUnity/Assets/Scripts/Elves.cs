using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elves : MonoBehaviour
{
    private GameObject fxPrefab;
    // Start is called before the first frame update
    void Start()
    {
        fxPrefab = GameObject.Find("GreenBloodSplatCritical2D");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll) {
        Debug.Log("tag = " + coll.collider.tag);
        if (coll.collider.tag == "Player") {
            fxPrefab.SetActive(true);
            GameObject fxCollect = Instantiate(fxPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
