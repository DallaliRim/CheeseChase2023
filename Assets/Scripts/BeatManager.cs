using UnityEngine;

public struct Rhythm
{
    public float offset;
    public float bpm;
    public uint signatureTop;
    public uint signatureBottom;
}

public struct Music
{
    public Rhythm[] sections;
}


public class BeatManager : MonoBehaviour
{
    public static BeatManager Instance { get; private set; }

    private float _timeCurrent = 0;

    public bool Paused = false;
    public Music? Music { get; set; }

    private Rhythm? CurrentSection
    {
        get
        {
            if (!this.Music.HasValue)
            {
                return null;
            }

            Music music = this.Music.Value;
            for (int i = 0; i < music.sections.Length; i++)
            {
                if (
                    // Time is in the current section
                    this._timeCurrent >= music.sections[i].offset
                    &&
                    // Time is not in the next section
                    (i == music.sections.Length - 1 || this._timeCurrent < music.sections[i + 1].offset)
                )
                {
                    return music.sections[i];
                }
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
        {
            sections = new Rhythm[]
            {
                new() {
                    offset = 0,
                    bpm = 130,
                    signatureTop = 4,
                    signatureBottom = 4
                },
                new() {
                    offset = 5,
                    bpm = 120,
                    signatureTop = 4,
                    signatureBottom = 4
                }
            }
        };
    }


    private void Update()
    {
        if (!this.Paused && this.CurrentSection.HasValue)
        {
            Rhythm section = this.CurrentSection.Value;

            this._timeCurrent += Time.deltaTime;
            float timeSection = this._timeCurrent - section.offset;

            float beatDuration = 60.0f / section.bpm / (section.signatureBottom / 4);

            float beat = (timeSection / beatDuration % section.signatureTop) + 1;
            int bar = Mathf.FloorToInt(timeSection / beatDuration / section.signatureTop) + 1;

            Debug.Log($"{this._timeCurrent} = {bar}:{beat} in section {section.offset} - {section.bpm} BPM - {section.signatureTop}/{section.signatureBottom}");
        }
    }
}
