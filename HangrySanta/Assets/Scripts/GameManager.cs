using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // to load scenes
using TMPro;    // TextMesh Pro

public class GameManager : MonoBehaviour
{
    public int itemPoints = 250;
    public int poisonPoints = -500;
    public float damage = 0.5f;
    public TextMeshProUGUI scoreTMPro;
    public GameObject healthContainer;
    private SpriteRenderer[] candyCanes;
    private float health;

    private int score;

    void Awake() {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(scoreTMPro);
    }

    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame() {
        UpdateScore(0);
        candyCanes = healthContainer.GetComponentsInChildren<SpriteRenderer>();
        health = candyCanes.Length;
    }

    public void UpdateScore(int points) {
        score += points;
        scoreTMPro.text = score.ToString();
    }

    public void PlayerHurt() {
        foreach (SpriteRenderer cane in candyCanes) {
            if (cane.enabled == true) {
                float alpha = cane.color.a;
                alpha -= damage;   // each candy cane can be hurt 2 times for a total of 5 * 2 = 10 total health
                health -= damage;
                if (alpha > 0) {
                    cane.color = new Color(1,1,1,alpha);    // reduce the alpha on this candy cane to make it more transparent
                }
                else {
                    cane.enabled = false;   // if this puts the alpha below or equal to zero, make the sprite invisible
                }
                break;  // changed one of the candy canes so break before looping back to the other ones
            }
        }

        if (health <= 4) {
            GameOver();
        }
    }

    public void GameOver() {
        SceneManager.LoadScene(2);      // loads the 3rd scene in the build order which is the gameover screen
    }


}
