using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeLeft : MonoBehaviour
{
    public GameObject police;
    public GameOver gameOver;
    private TextMeshProUGUI timeText;
    private float TimeRemaining => BeatManager.Instance.TimeLeft;
    private bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = $"Time: {FormatTime(TimeRemaining)}";

        if (TimeRemaining <= 30 && !spawned)
        {
            GameObject policeRef = Instantiate(police);
            policeRef.transform.position = new Vector3(0, -4);
            spawned = true;
        }
        timeText.text += $"\nPolice Arrive In: {FormatTime(TimeRemaining - 30)}";
        timeText.text += $"\nEscape Available In: {FormatTime(30 - BeatManager.Instance.Audio.time)}";

        if (!PauseMenu.isPaused && !BeatManager.Instance.Audio.isPlaying)
        {
            gameOver.ShowEndScreen(false);
        }
    }

    private static string FormatTime(float time)
    {
        if (time < 0)
        {
            return "0:00";
        }
        int minute = (int)(time / 60);
        int seconds = (int)(time % 60);
        return $"{minute}:{(seconds < 10 ? "0" + seconds : seconds)}";
    }
}
