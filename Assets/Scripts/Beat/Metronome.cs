using UnityEngine;

public class Metronome : MonoBehaviour
{
    public AudioClip strong;
    public AudioClip weak;

    public AudioSource source;

    public void Start() { }
    public void Update() { }

    public void Click(Beat beat)
    {
        source.PlayOneShot(beat.beatRounded == 1 ? this.strong : this.weak);
    }
}
