using UnityEngine;

public readonly struct Rhythm
{
    public readonly float bpm;
    public readonly uint signatureTop;
    public readonly uint signatureBottom;

    public Rhythm(float bpm, uint signatureTop, uint signatureBottom)
    {
        this.bpm = bpm;
        this.signatureTop = signatureTop;
        this.signatureBottom = signatureBottom;
    }
}

public readonly struct Music
{
    public readonly Rhythm rhythm;

    public Music(Rhythm rhythm)
    {
        this.rhythm = rhythm;
    }
}

public readonly struct Beat
{
    public readonly int bar;
    public readonly float beat;

    public Beat(int bar, float beat)
    {
        this.bar = bar;
        this.beat = beat;
    }
}


public class BeatManager : MonoBehaviour
{
    public static BeatManager Instance { get; private set; }

    public bool Paused = false;
    public Music? Music { get; set; }

    public Beat Beat { get; private set; }

    public float CurrentTime { get; private set; } = 0;

    private bool IsPlayable { get => !this.Paused && this.Music.HasValue; }

    private float? BeatDuration
    {
        get
        {
            if (this.IsPlayable)
            {
                Rhythm rhythm = this.Music.Value.rhythm;
                return 60.0f / rhythm.bpm / (rhythm.signatureBottom / 4);
            }
            return null;
        }
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

    private void Start()
    {
        // TODO: Remove later, test code
        this.Music = new Music
        (
            rhythm: new Rhythm
            (
                bpm: 120,
                signatureTop: 4,
                signatureBottom: 4
            )
        );
    }

    private void Update()
    {
        if (this.IsPlayable)
        {
            this.CurrentTime += Time.deltaTime;
            this.Beat = this.GetBeatAt(CurrentTime).Value;
            Time.fixedDeltaTime = BeatDuration.Value;
        }
    }

    private Beat? GetBeatAt(float time)
    {
        if (this.IsPlayable)
        {
            Rhythm rhythm = this.Music.Value.rhythm;
            float beatDuration = this.BeatDuration.Value;

            return new Beat
            (
                bar: Mathf.FloorToInt(this.CurrentTime / beatDuration / rhythm.signatureTop) + 1,
                beat: (this.CurrentTime / beatDuration % rhythm.signatureTop) + 1
            );
        }
        return null;
    }
}
