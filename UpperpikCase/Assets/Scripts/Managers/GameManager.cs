using System.Collections;
using System.Collections.Generic;
using Controllers;
using Managers;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI woodCountText;
    private float _sayac = 0;
    [SerializeField] public List<Transform> players;
     public int Multiplier { get; set; } 

    public int WoodCount { get; set; } = 0;

    private void Awake()
    {
        instance = this;
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        woodCountText.text = "" + WoodCount;
    }

    public IEnumerator ActivateWood(GameObject other)
    {
       
        yield return new WaitForSeconds(2);
        other.gameObject.SetActive(true);
    }

    public void Flying()
    {
        _sayac += Time.deltaTime;
        if (!(_sayac >= 0.15f)) return;
        WoodCount--;
        _sayac = 0;
    }
    
    public void Insertionsort(List<Transform> input)
    {
        for (int i = 1; i < input.Count; i++)
        {
            Transform temp = input[i];
            int j;
            for (j = i-1; j>=0 &&  input[j].position.z >temp.position.z; j--)
            {
                input[j + 1] = input[j];
            }
            input[j + 1] = temp;
        }
    }
    public void GameFinished()
    {
        
    }
    public void GameStart()
    {
        UIManager.instance.ActivateLoadingPanel();
        WoodCount = 0;
        UIManager.instance.GameStart();
        StartCoroutine(nameof(WaitingLoad));
    }

    IEnumerator WaitingLoad()
    {
        players[0].GetComponent<PlayerMovementController>().PlayerStartAction();
        yield return new WaitForSeconds(2f);
        LevelManager.instance.CreateLevel();
        UIManager.instance.DeActivateLoadingPanel();
    }
}
