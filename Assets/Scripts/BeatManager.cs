using UnityEngine;

public struct Rhythm
{
    public float bpm;
    public uint signatureTop;
    public uint signatureBottom;
}

public struct Music
{
    public Rhythm rhythm;
}


public class BeatManager : MonoBehaviour
{
    public static BeatManager Instance { get; private set; }

    public bool Paused = false;
    public Music? Music { get; set; }

    public float Beat { get; private set; }
    public float Bar { get; private set; }

    private float _timeCurrent = 0;

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
        {
            rhythm = new Rhythm
            {
                bpm = 120,
                signatureTop = 4,
                signatureBottom = 4
            }
        };
    }

    private void Update()
    {
        if (!this.Paused && this.Music.HasValue)
        {
            Rhythm section = this.Music.Value.rhythm;

            this._timeCurrent += Time.deltaTime;

            float beatDuration = 60.0f / section.bpm / (section.signatureBottom / 4);

            this.Beat = (this._timeCurrent / beatDuration % section.signatureTop) + 1;
            this.Bar = Mathf.FloorToInt(this._timeCurrent / beatDuration / section.signatureTop) + 1;
        }
    }
}
