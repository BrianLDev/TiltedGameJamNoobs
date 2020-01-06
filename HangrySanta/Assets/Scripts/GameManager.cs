using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // TextMesh Pro

public class GameManager : MonoBehaviour
{
    public int itemPoints = 250;
    public int poisonPoints = -500;
    public int elfDeathPoints = -1500;
    public TextMeshProUGUI scoreText;
    public GameObject itemSpawner;
    public GameObject Rudolph;
    public GameObject Santa;
    public GameObject[] elves;


    private int score;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
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
