using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;



public class CoinCalculateAnim : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private int tempCoinAmount;
    private int coin;
    void OnEnable()
    {
        DOTween.Init();
        ChangeCoinAmount(0);
        tempCoinAmount = CalculateCoin() * GameManager.instance.Multiplier;
        StartCoroutine(CalculateCoinEnumerator(tempCoinAmount));
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text =" "+coin;
    }
    
    int GetCoinAmount()
    {
        return coin;
    }

    void ChangeCoinAmount(int value)
    {
        coin = value;
    }
    IEnumerator CalculateCoinEnumerator(int value)
    {
        yield return new WaitForSeconds(1.5f);

        DOTween.To(() => coin, (value) => coin = value, value, 2f);
    }

    int CalculateCoin()
    {
        int tempRank = UIManager.instance.GetPlayerRank();
        int reward = 0;
       

        switch (tempRank)
        {
           case 0:
               reward = 30;
               break;
           case 1:
               reward = 20;
               break;
           case 2:
               reward = 10;
               break;
        }

        return reward;
    }
    
    
}
