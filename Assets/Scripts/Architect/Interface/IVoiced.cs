
using UnityEngine;

public interface IVoiced
{
    public AudioClip AudioClip { get; }
    public void SetAudioSource(IPlayingAudio audioSource);
}
