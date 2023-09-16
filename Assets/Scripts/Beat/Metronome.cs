using UnityEngine;

public class Metronome : MonoBehaviour
{
    public AudioClip strong;
    public AudioClip weak;

    private void FixedUpdate()
    {
        Beat beat = BeatManager.Instance.Beat;
        AudioSource.PlayClipAtPoint(beat.beatRounded == 1 ? this.strong : this.weak, Camera.main.transform.position);
    }
}
