using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public readonly struct Beat
{
    public readonly int bar;
    public readonly float beatPrecise;
    public readonly int beatRounded;

    public Beat(int bar, float beatPrecise)
    {
        this.bar = bar;
        this.beatPrecise = beatPrecise;
        this.beatRounded = Mathf.FloorToInt(beatPrecise);
    }
}


public class BeatManager : MonoBehaviour
{
    public static BeatManager Instance { get; private set; }

    public UnityEvent<Beat> OnBeat;

    public float Precision = 0.2f;
    public float Offset = 0.0f;
    public float Bpm = 120;
    public uint SignatureTop = 4;
    public uint SignatureBottom = 4;

    public AudioSource Audio;

    public Beat Beat { get; private set; } = new(1, 1);
    private Beat _beatPrevious = new(1, 0);

    private float BeatDuration => 60.0f / this.Bpm / (this.SignatureBottom / 4);

    public bool IsOnBeat { get => IsCloseToInt(this.Beat.beatPrecise, this.Precision); }

    public float TimeLeft => this.Audio.clip.length - this.Audio.time;

    private static bool IsCloseToInt(float f, float precision)
    {
        return
            Mathf.Abs(f - Mathf.Floor(f)) < precision
            || Mathf.Abs(f - Mathf.Ceil(f)) < precision;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            this._beatPrevious = this.Beat;
            this.Beat = this.ComputeBeatAt(this.Audio.time);

            if (this.Beat.beatRounded != this._beatPrevious.beatRounded)
            {
                this.OnBeat.Invoke(this.Beat);
            }
        }

    }

    private Beat ComputeBeatAt(float time)
    {
        time += this.Offset;

        return new Beat
        (
            bar: Mathf.FloorToInt(time / this.BeatDuration / this.SignatureTop) + 1,
            beatPrecise: (time / this.BeatDuration) % this.SignatureTop + 1
        );
    }
}
