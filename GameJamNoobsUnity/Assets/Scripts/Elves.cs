using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elves : MonoBehaviour
{
    public float speed = 0.06f;      // default to 0.06
    public GameObject fxPrefab;

    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveSpd = new Vector3(-speed,0,0);
        // rb2D.Translate(moveSpd);
        
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.tag == "Player") {
            Instantiate(fxPrefab, this.transform.position, Quaternion.identity);
            Destroy(fxPrefab, 3f);     // kill off the effect after 3 seconds
            Destroy(this.gameObject);
            Debug.Log("Destroyed elf!");
        }
    }
}
