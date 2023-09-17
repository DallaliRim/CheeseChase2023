using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeLeft : MonoBehaviour
{
    private TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = BeatManager.Instance.TimeLeft;
        int minute = (int)(time / 60);
        int seconds = (int)(time % 60);
        timeText.text = $"Time: {minute}:{(seconds < 10 ? "0" + seconds : seconds)}";
        Debug.Log(timeText.text);
    }
}
