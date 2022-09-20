using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelPrefabs mLevelPrefabs = null;
        private int currentLevel;
        private GameObject _currentLevelObject;
        public static LevelManager instance;

        void Start()
        {
        CreateLevel();
        instance = this;
        }
        void Update()
        {
        
        }

        public void LevelFinished()
        {
        SaveLevel();
        
        }

        public void CreateLevel()
        {

            Destroy(_currentLevelObject); 
            
            currentLevel = PrefsManager.instance.GetLevel();
            if (currentLevel==0)
            {
                currentLevel = 1;
            }
            
            int levelIndex = currentLevel % mLevelPrefabs.LevelList.Count;
            _currentLevelObject = Instantiate(mLevelPrefabs.LevelList[levelIndex]);
            _currentLevelObject.transform.position=Vector3.zero;
            SaveLevel();
        }

        public void SaveLevel()
        {
            PrefsManager.instance.SaveLevel(currentLevel+1);
        }
    }

}
