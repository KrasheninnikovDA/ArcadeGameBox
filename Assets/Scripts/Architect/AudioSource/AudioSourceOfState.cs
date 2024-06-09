/// класс - переключатель звуков. Для передачи клипа используется интерфейс IVoiced
using UnityEngine;

public class AudioSourceOfState : MonoBehaviour, IPlayingAudio
{
    [SerializeField] private AudioSource source;

    public void PlayAudioClip(IVoiced voice, bool loop)
    {
        source.clip = voice.AudioClip;
        source.loop = loop;
        source.Play();
    }

    public void StopAudioClip()
    {
        source.Stop();
    }
}
