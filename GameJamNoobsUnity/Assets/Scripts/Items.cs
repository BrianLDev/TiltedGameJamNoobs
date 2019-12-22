using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public float speed = 0.07f;      // default to 0.07
    
    private GameObject fxPrefab;
    private Transform itemTfm;
    // Start is called before the first frame update
    void Start()
    {
        itemTfm = GetComponent<Transform>();
        fxPrefab = GameObject.Find("StarBurst2D");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newLoc = new Vector3(-speed,0,0);
        itemTfm.Translate(newLoc);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            fxPrefab.SetActive(true);
            GameObject fxCollect = Instantiate(fxPrefab, itemTfm.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }


}
