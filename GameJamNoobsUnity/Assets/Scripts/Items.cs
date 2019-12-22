using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public float speed = 0.07f;      // default to 0.07
    private Transform item;
    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newLoc = new Vector3(-speed,0,0);
        item.Translate(newLoc);
    }

    void OnTriggerEnter2D() {
        Destroy(this.gameObject);
    }


}
