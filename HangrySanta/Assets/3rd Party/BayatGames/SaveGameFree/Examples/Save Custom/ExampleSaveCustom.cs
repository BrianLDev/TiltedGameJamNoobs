using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BayatGames.SaveGameFree.Examples
{

    public class ExampleSaveCustom : MonoBehaviour
    {

        [System.Serializable]
        public struct Level
        {
            public bool unlocked;
            public bool completed;

            public Level(bool unlocked, bool completed)
            {
                this.unlocked = unlocked;
                this.completed = completed;
            }
        }

        [System.Serializable]
        public class CustomData
        {

            public int score;
            public int highScore;
            public bool loadOnStart;    // BL: Added this
            public List<Level> levels;

            public CustomData()
            {
                score = 0;
                highScore = 0;
                loadOnStart = true;     // BL: Added this

                // Dummy data
                levels = new List<Level>() {
                    new Level ( true, false ),
                    new Level ( false, false ),
                    new Level ( false, true ),
                    new Level ( true, false )
                };
            }

        }

        public CustomData customData;
        public InputField scoreInputField;
        public InputField highScoreInputField;
        public Toggle loadOnStartToggle;    // BL: Added this
        public string identifier = "exampleSaveCustom";

        void Start()
        {
        //     if (loadOnStart)
        //     {
        //         Load();
        //     }
            LoadOnStart();      // BL: Added this
        }

        public void SetScore(string score)
        {
            customData.score = int.Parse(score);
        }

        public void SetHighScore(string highScore)
        {
            customData.highScore = int.Parse(highScore);
        }

        public void SetLoadOnStart(bool isOn) {       // BL: Added this function
            customData.loadOnStart = loadOnStartToggle.isOn;
        }

        public void Save()
        {
            Debug.Log("Saving...");
            SaveGame.Save<CustomData>(identifier, customData, SerializerDropdown.Singleton.ActiveSerializer);
        }

        public void Load()
        {
            Debug.Log("Loading...");
            customData = SaveGame.Load<CustomData>(
                identifier,
                new CustomData(),
                SerializerDropdown.Singleton.ActiveSerializer);
            scoreInputField.text = customData.score.ToString();
            highScoreInputField.text = customData.highScore.ToString();
        }

        public void LoadOnStart()   // BL: Added this function
        {
            Debug.Log("Checking to load on start...");
            CustomData tempCustomData = SaveGame.Load<CustomData>(
                identifier,
                new CustomData(),
                SerializerDropdown.Singleton.ActiveSerializer);
            if (tempCustomData.loadOnStart) {   // only replace the score strings if loadOnStart true
                Debug.Log("Loading data on start...");
                customData = tempCustomData;
                scoreInputField.text = customData.score.ToString();
                highScoreInputField.text = customData.highScore.ToString();
                loadOnStartToggle.isOn = customData.loadOnStart;
            }
            else {
                Debug.Log("Not loading data on start...");
            }
        }

    }

}