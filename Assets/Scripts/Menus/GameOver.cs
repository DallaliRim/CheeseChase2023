using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI redPlayerText;
    public TextMeshProUGUI bluePlayerText;
    public TextMeshProUGUI result;
    public TextMeshProUGUI gameover;
    public Manager_Money moneyManager;
    public GridMovement playerRed;
    public GridMovement playerBlue;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowEndScreen(bool win)
    {
        int red = moneyManager.cheesePlayerRed + moneyManager.cheeseVanPlayerRed;
        int blue = moneyManager.cheesePlayerBlue + moneyManager.cheeseVanPlayerBlue;

        redPlayerText.text = win ? $"Red Thief: {red} cheeses" : "";
        bluePlayerText.text = win ? $"Blue Thief: {blue} cheeses" : "";
        result.text = win ? "You Escaped Successfully!" : "You Got Caught. ):";
        gameover.text = win ? "HEIST COMPLETE" : "GAME OVER";
        gameObject.SetActive(true);
        PauseMenu.isPaused = true;
    }

    public void CheckGameEnd() 
    {
        if(playerRed.playerStatus == PlayerStatus.InJail && playerBlue.playerStatus == PlayerStatus.InJail)
        {
            ShowEndScreen(false);
        } else if (playerRed.playerStatus != PlayerStatus.InGame && playerBlue.playerStatus != PlayerStatus.InGame)
        {
            ShowEndScreen(true);
        }
    }

    public void Restart()
    {
        PauseMenu.isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit() 
    {
        Application.Quit();
    }
}
