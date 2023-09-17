using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI redPlayerText;
    public TextMeshProUGUI bluePlayerText;
    public Manager_Money moneyManager;
    public void setup(int score)
    {
        gameObject.SetActive(true);
        redPlayerText.text = $"Red Thief: {moneyManager.moneyPlayerRed} $$";
        bluePlayerText.text = $"Blue Thief: {moneyManager.moneyPlayerBlue} $$";
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
