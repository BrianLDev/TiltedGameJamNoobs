using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // to load scenes
using Doozy.Engine;    // Doozy UI 
using TMPro;    // TextMesh Pro
using BayatGames.SaveGameFree.Types;    // to save score

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;  // public instance of this GameManager that all scripts can access (singleton)
    public enum GameState {MainMenu = 0, PlayingGame = 1, Paused = 3, GameOver = 4}
    public GameState gameState = GameState.MainMenu;
    public int itemPoints = 250;
    public int poisonPoints = -500;
    public float damage = 0.5f;
    public TextMeshProUGUI scoreTMPro;
    public GameObject healthContainer;
    private SpriteRenderer[] candyCanes;
    private float health;
    private int score;
    private GameEventListener gameEventListener;    //  TODO: figure out how to get this to listen for STARTGAME

    void Awake() {
        if (instance == null)   // Check if instance already exists
            instance = this;    // if not, set instance to this

        else if (instance != this)  // If instance already exists and it's not this:
            // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);    

        DontDestroyOnLoad(gameObject);  // Sets this to not be destroyed when reloading scene
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
                Debug.Log("Taking damage!!");
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
        Debug.Log("Game Over man...");
        gameState = GameState.GameOver;
        // TODO: Add save game logic here
        // SaveGame​.​Save​<int>​ ​(​ ​"score"​,​ score ​);
        GameEventMessage.SendEvent("GAMEOVER");
    }


}
