using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // TextMesh Pro

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject itemSpawner;
    public GameObject Rudolph;
    public GameObject Santa;
    public GameObject[] elves;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int points) {
        score += points;
        scoreText.text = score.ToString();
    }
}
