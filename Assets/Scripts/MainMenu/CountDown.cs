using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public Text countdownText;
    public float countdownDuration = 1.0f;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(1.0f);
        countdownText.text = "3";
        yield return new WaitForSeconds(countdownDuration);

        countdownText.text = "2";
        yield return new WaitForSeconds(countdownDuration);

        countdownText.text = "1";
        yield return new WaitForSeconds(countdownDuration);

        countdownText.text = "Go!";
        yield return new WaitForSeconds(countdownDuration);

        countdownText.gameObject.SetActive(false); // Hide the countdown text
    }
}
