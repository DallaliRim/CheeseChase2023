using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicController : MonoBehaviour
{
    AudioSource audioSource;
    bool playing => audioSource.isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused && !playing)
        {
            audioSource.Play();
        }
        else if (PauseMenu.isPaused && playing)
        {
            audioSource.Pause();
        }
    }
}
