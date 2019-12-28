using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elves : MonoBehaviour
{
    public float speed = 2f;      // default to 2
    public GameObject fxPrefab;

    private Rigidbody2D rb2D;
    private Vector2 forceToAdd;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,100) <= 2) {
            // xx% of the time, change the force and direction velocity of the elf to simulate moving running, jogging, slowing down
            speed = Random.Range(-1f, 0.5f) * 2.25f;  
            forceToAdd = new Vector2(speed, 0f);
        }
        rb2D.AddForce(forceToAdd);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.tag == "Player") {
            // Instantiate(fxPrefab, this.transform.position, Quaternion.identity);
            // Destroy(fxPrefab, 3f);     // kill off the effect after 3 seconds
            // Destroy(this.gameObject);

            Vector2 nudge = new Vector2 (15f, 40f);
            rb2D.AddForce(nudge);
        }
    }
}
