
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI woodCountText;

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
        Debug.Log(".ağrıldı");
        yield return new WaitForSeconds(2);
        other.gameObject.SetActive(true);
    }
}
