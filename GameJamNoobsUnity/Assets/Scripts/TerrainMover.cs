using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainMover : MonoBehaviour
{
    public float speed = 0.07f;      // default to 0.07
    private RectTransform terrain;
    
    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveSpd = new Vector3(-speed,0,0);
        terrain.Translate(moveSpd);
        if (terrain.position.x <= -15) {
            terrain.position = new Vector2(terrain.position.x + (terrain.rect.width * 7) - 0.1f, terrain.position.y);
        }
    }

    public void FixedUpdate() {

    }
}
