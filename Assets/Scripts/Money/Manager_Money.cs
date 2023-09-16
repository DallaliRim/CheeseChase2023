using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Manager_Money : MonoBehaviour
{

    [Header("Money the players are holding")]
    public int moneyPlayerBlue = 0;
    public int moneyPlayerRed = 0;

    // this is just here so the money gameobjects can tell if max limit has been reached or not. 
    // should not use this for anything else. Need to use debug.log() to look at their values.
    public static int moneyPlayerBlueOnHand;
    public static int moneyPlayerRedOnHand;

    [Header("Money players have in vans")]
    public int moneyVanPlayerBlue = 0;
    public int moneyVanPlayerRed = 0;

    [Header("References to the money UI")]
    public TextMeshProUGUI moneyTextBlue;
    public TextMeshProUGUI moneyTextRed;

    public TextMeshProUGUI moneyInVanRed;
    public TextMeshProUGUI moneyInVanBlue;

    [Header("How much money player should get per second in vault")]
    public int moneyPerSecond;
    [Header("How much money player picks up per money object collected")]
    public int moneyAmount = 5000;

    [Header("How much money a player can carry at a time.")]
    public static int maxMoneyAmount = 10000;

    void Update()
    {
        moneyTextBlue.text = "Money: " + moneyPlayerBlue.ToString();
        moneyTextRed.text = "Money: " + moneyPlayerRed.ToString();

        moneyInVanBlue.text = "Collected: " + moneyVanPlayerBlue.ToString();
        moneyInVanRed.text = "Collected: " + moneyVanPlayerRed.ToString();

        // so the 2 can be in sync
        moneyPlayerBlueOnHand = moneyPlayerBlue;
        moneyPlayerRedOnHand = moneyPlayerRed;
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

    public void BlueDepositsMoney()
    {
        moneyVanPlayerBlue += moneyPlayerBlue;
        moneyPlayerBlue = 0;
    }

    public void RedDepositsMoney()
    {
        moneyVanPlayerRed += moneyPlayerRed;
        moneyPlayerRed = 0;
    }

}
