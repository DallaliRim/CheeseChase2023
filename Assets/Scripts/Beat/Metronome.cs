using UnityEngine;

public class Metronome : MonoBehaviour
{
    public AudioClip strong;
    public AudioClip weak;

    public static bool IsBeat(float beat, float target)
    {
        return Mathf.Abs(beat - target) < 0.1;
    }

    private void FixedUpdate()
    {
        Beat beat = BeatManager.Instance.Beat;
        AudioSource.PlayClipAtPoint(IsBeat(beat.beat, 1) ? this.strong : this.weak, Camera.main.transform.position);
    }
}
