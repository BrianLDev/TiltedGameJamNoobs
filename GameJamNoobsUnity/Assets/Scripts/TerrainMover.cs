using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainMover : MonoBehaviour
{
    public float speed = 0;
    private RectTransform terrain;
    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newLoc = new Vector3(-speed,0,0);
        terrain.Translate(newLoc);
    }
}
