using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Manager_Money : MonoBehaviour
{

    [Header("Money amounts for the left player and right player")]
    public int moneyPlayerBlue = 0;
    public int moneyPlayerRed = 0;
    [Header("References to the money UI")]
    public TextMeshProUGUI moneyTextBlue;
    public TextMeshProUGUI moneyTextRed;

    [Header("How much money player should get per second in vault")]
    public int moneyPerSecond;
    [Header("How much money player picks up per money object collected")]

    public int moneyAmount;

    void Update()
    {
        moneyTextBlue.text = "Money: " + moneyPlayerBlue.ToString();
        moneyTextRed.text = "Money: " + moneyPlayerRed.ToString();
    }


    public void IncreaseMoneyForBluePlayer()
    {
        moneyPlayerBlue += moneyPerSecond;
    }

    public void IncreaseMoneyForRedPlayer()
    {
        moneyPlayerRed += moneyPerSecond;
    }

    public void BluePicksUpMoney()
    {
        moneyPlayerBlue += moneyAmount;
    }

    public void RedPicksUpMoney()
    {
        moneyPlayerRed += moneyAmount;
    }

}
