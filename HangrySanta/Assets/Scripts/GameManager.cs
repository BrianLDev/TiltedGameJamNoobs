using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // TextMesh Pro

public class GameManager : MonoBehaviour
{
    public int itemPoints = 250;
    public int poisonPoints = -500;
    public TextMeshProUGUI scoreText;
    public GameObject healthContainer;
    private SpriteRenderer[] candyCanes;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        candyCanes = healthContainer.GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int points) {
        score += points;
        scoreText.text = score.ToString();
    }

    public void PlayerHurt() {
        foreach (SpriteRenderer cane in candyCanes) {
            if (cane.enabled == true) {
                float alpha = cane.color.a;
                Debug.Log("alpha before = " + alpha);
                alpha -= .5f;   // each candy cane can be hurt 2 times for a total of 5 * 2 = 10 total health
                Debug.Log("alpha after = " + alpha);
                if (alpha > 0) {
                    cane.color = new Color(1,1,1,alpha);    // reduce the alpha on this candy cane to make it more transparent
                }
                else {
                    cane.enabled = false;   // if this puts the alpha below or equal to zero, make the sprite invisible
                }
                break;  // changed one of the candy canes so break before looping back to the other ones
            }
        }
    }


}
