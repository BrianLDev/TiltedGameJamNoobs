﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public float speed = 0.07f;      // default to 0.07
    public int itemPoints = 5;
    public int poisonPoints = -10;
    public GameObject fxPrefab;
    private GameManager gameManager;
    
    private Transform itemTfm;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
        itemTfm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        Vector3 newLoc = new Vector3(-speed,0,0);
        itemTfm.Translate(newLoc);
    }

    void OnTriggerEnter2D(Collider2D col) {
        AddPoints(col);
        ItemConsumed(col);
    }

    void OnBecameInvisible() {
        // get rid of the item when it goes off screen
        Destroy(this.gameObject);
    }

    private void ItemConsumed(Collider2D col) {
        if (col.tag == "Player" || col.tag == "Santa") {
            GameObject itemFX = Instantiate(fxPrefab, itemTfm.position, Quaternion.identity);
            itemFX.transform.parent = GameObject.Find("_Dynamic").transform;
            Destroy(this.gameObject);
            Destroy(itemFX, 3f);     // Destroy the fx gameObject after 3 seconds
        }
    }

    private void AddPoints(Collider2D col) {
        if (col.tag == "Player") {
            if (gameObject.tag == "poison") {
                gameManager.UpdateScore(poisonPoints);
            }
            else {
                gameManager.UpdateScore(itemPoints);
            }
        }
        if (col.tag == "Santa") {
            if (gameObject.tag == "poison") {
                gameManager.UpdateScore(-poisonPoints);
            }
            else {
                gameManager.UpdateScore(-itemPoints);
            }
        }
    }

}
