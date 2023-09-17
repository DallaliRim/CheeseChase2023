using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI redPlayerText;
    public TextMeshProUGUI bluePlayerText;
    public TextMeshProUGUI result;
    public TextMeshProUGUI gameover;
    public Manager_Money moneyManager;
    public void setup(bool win)
    {
        gameObject.SetActive(true);
        redPlayerText.text = win ? $"Red Thief: {moneyManager.moneyPlayerRed} $$" : "";
        bluePlayerText.text = win ? $"Blue Thief: {moneyManager.moneyPlayerBlue} $$" : "";
        result.text = win ? "You Escaped Successfully!" : "You Got Caught. ):";
        gameover.text = win ? "HEIST COMPLETE" : "GAME OVER";
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit() 
    {
        Application.Quit();
    }
}
