using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PrefsManager : MonoBehaviour
    {
        public int Coin { get; set; } = 0;
        public int LevelCount;
        public static PrefsManager instance;

        private void Awake()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void SaveCoinCount(int value)
        {
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + value);
        }
    
        public void SaveLevel(int value)
        {
            PlayerPrefs.SetInt("Level", value);
        }

        public int GetLevel()
        {
            return PlayerPrefs.GetInt("Level");
        }

    
    }


