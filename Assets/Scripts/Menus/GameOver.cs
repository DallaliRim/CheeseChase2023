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
    public GridMovement player1;
    public GridMovement player2;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowEndScreen(bool win)
    {
        gameObject.SetActive(true);
        redPlayerText.text = win ? $"Red Thief: {moneyManager.cheesePlayerRed} $$" : "";
        bluePlayerText.text = win ? $"Blue Thief: {moneyManager.cheesePlayerBlue} $$" : "";
        result.text = win ? "You Escaped Successfully!" : "You Got Caught. ):";
        gameover.text = win ? "HEIST COMPLETE" : "GAME OVER";
    }

    public void CheckGameEnd() 
    {
        if(player1.playerStatus == PlayerStatus.InJail && player2.playerStatus == PlayerStatus.InJail)
        {
            ShowEndScreen(false);
        } else if (player1.playerStatus != PlayerStatus.InGame && player2.playerStatus != PlayerStatus.InGame)
        {
            ShowEndScreen(true);
        }
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
