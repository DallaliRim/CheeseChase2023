using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownController : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public GameObject countdown;
    public float countdownDuration = 1.0f;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        PauseMenu.isPaused = true;
        yield return new WaitForSeconds(1.0f);
        countdownText.text = "3";
        yield return new WaitForSeconds(countdownDuration);

        countdownText.text = "2";
        yield return new WaitForSeconds(countdownDuration);

        countdownText.text = "1";
        yield return new WaitForSeconds(countdownDuration);

        countdownText.text = "Go!";
        yield return new WaitForSeconds(countdownDuration);

        GameObject.FindGameObjectWithTag("countdown").SetActive(false);
        Time.timeScale = 1.0f;
        PauseMenu.isPaused = false;
    }
}
