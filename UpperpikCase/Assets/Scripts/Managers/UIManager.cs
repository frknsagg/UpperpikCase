using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button startButton;
    [SerializeField] private Image[] standingsImages;
    public static UIManager instance;
    [SerializeField] private GameObject nextLevelPanel;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject loadingPanel;
    

    private void Awake()
    {
        instance = this;
    }

    public void GameStartButton()
    {
        player.gameObject.GetComponent<PlayerAnimationController>().RunPlayerMovementAnimation();
        player.gameObject.GetComponent<PlayerMovementController>().EnableMovement();
        LevelTextChange(PrefsManager.instance.GetLevel());
        DeActiveStartButton();
    }
   public void ActiveStartButton()
    {
        startButton.gameObject.SetActive(true);
    }

    void DeActiveStartButton()
    {
       startButton.gameObject.SetActive(false);
    }

    public void GameFinished()
    {
        ActivateFinishPanel();
        standingsImages[GetPlayerRank()].gameObject.SetActive(true);
        levelText.enabled = false;
    }

   
    public void ActivateFinishPanel()
    {
        finishPanel.SetActive(true); 
    }
    public void DeActivateFinishPanel()
    {
        finishPanel.SetActive(false); 
    }

    public void ActivateNextLevelPanel()
    {
        nextLevelPanel.SetActive(true);
    }
    public void DeActivateNextLevelPanel()
    {
        nextLevelPanel.SetActive(false);
    }

    public int GetPlayerRank()
    {
        int rank = Enumerable.Reverse(GameManager.instance.players).ToList().IndexOf(player.transform);
        return rank;
       
    }

    public void ActivateGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void LevelTextChange(int level)
    {
        levelText.text = "Level " + level;
    }

    public void GameStart()
    {
        levelText.enabled = true;
        levelText.text = "Level " + PrefsManager.instance.GetLevel();
        ActiveStartButton();
        DeActivateFinishPanel();
        DeActivateNextLevelPanel();
    }
    public void ActivateLoadingPanel()
    {
        loadingPanel.SetActive(true);
    }
    public void DeActivateLoadingPanel()
    {
        loadingPanel.SetActive(false);
    }
    
}
