using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour
{
    public float growthMultiplier = 1.05f;
    public float shrinkMultiplier = 0.9f;
    private Transform santaTfm;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        santaTfm = GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "Items") {
            santaTfm.localScale *= growthMultiplier;
            // santaTfm.localScale.Set(santaTfm.localScale.x * 1.5f, santaTfm.localScale.y, santaTfm.localScale.z);  // make him even wider
            rb2D.mass *= growthMultiplier;
        }
        if (coll.tag == "Poison") {
            santaTfm.localScale *= shrinkMultiplier;
            // santaTfm.localScale.Set(santaTfm.localScale.x * .5f, santaTfm.localScale.y, santaTfm.localScale.z);  // less wide
            rb2D.mass *= shrinkMultiplier;
        }
        if (coll.tag == "Elves") {
            Debug.Log("DEAD ELF!!");
        }
    }
}
