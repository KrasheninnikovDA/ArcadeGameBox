
using UnityEngine;

public class AudioSourceOfState : MonoBehaviour, IPlayingAudio
{
    [SerializeField] private AudioSource source;

    public void PlayAudioClip(IVoiced voice)
    {
        source.clip = voice.AudioClip;
        source.Play();
    }

    public void StopAudioClip()
    {
        source.Stop();
    }
}
