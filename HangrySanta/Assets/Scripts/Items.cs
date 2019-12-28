using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public float speed = 0.07f;      // default to 0.07
    public GameObject fxPrefab;
    
    private Transform itemTfm;
    // Start is called before the first frame update
    void Start()
    {
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
        fxPrefab = Instantiate(fxPrefab, itemTfm.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(fxPrefab, 3f);     // Destroy the fx gameObject after 3 seconds
    }

    void OnBecameInvisible() {
        // get rid of the item when it goes off screen
        Destroy(this.gameObject);
    }


}
