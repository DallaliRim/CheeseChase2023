using TMPro;
using UnityEngine;

public class Manager_Money : MonoBehaviour
{

    [Header("Money the players are holding")]
    public int cheesePlayerBlue = 0;
    public int cheesePlayerRed = 0;

    // this is just here so the money gameobjects can tell if max limit has been reached or not. 
    // should not use this for anything else. Need to use debug.log() to look at their values.
    public static int cheesePlayerBlueStatic;
    public static int cheesePlayerRedStatic;

    [Header("Money players have in vans")]
    public int cheeseVanPlayerBlue = 0;
    public int cheeseVanPlayerRed = 0;

    [Header("References to the money UI")]
    public TextMeshProUGUI cheesePlayerBlueText;
    public TextMeshProUGUI cheesePlayerRedText;

    public TextMeshProUGUI cheeseVanBlueText;
    public TextMeshProUGUI cheeseVanRedText;

    [Header("How much money player picks up per money object collected")]
    public int cheeseAmount = 16;

    void Update()
    {
        cheesePlayerBlue = Mathf.Max(cheesePlayerBlue, 0);
        cheesePlayerRed = Mathf.Max(cheesePlayerRed, 0);

        cheesePlayerBlueText.text = $"Pocket: {cheesePlayerRed} cheese";
        cheesePlayerRedText.text = $"Pocket: {cheesePlayerBlue} cheese";

        cheeseVanBlueText.text = $"Collected: {cheeseVanPlayerRed} cheese";
        cheeseVanRedText.text = $"Collected: {cheeseVanPlayerBlue} cheese";

        // so the 2 can be in sync
        cheesePlayerBlueStatic = cheesePlayerBlue;
        cheesePlayerRedStatic = cheesePlayerRed;
    }

    public void BluePicksUp()
    {
        cheesePlayerBlue = cheeseAmount;
    }

    public void RedPicksUp()
    {
        cheesePlayerRed = cheeseAmount;
    }

    public void BlueDeposits()
    {
        cheeseVanPlayerBlue += cheesePlayerBlue;
        cheesePlayerBlue = 0;
    }

    public void RedDeposits()
    {
        cheeseVanPlayerRed += cheesePlayerRed;
        cheesePlayerRed = 0;
    }

}
