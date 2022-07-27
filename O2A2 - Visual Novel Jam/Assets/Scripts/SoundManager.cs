using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] public AudioSource _musicSource, _effectSource, _voiceOverSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayVoiceOverSound(AudioClip clip)
    {
        _voiceOverSource.PlayOneShot(clip);
    }

    public void PlayEffectSound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }

    public void PlayMusicSource(AudioClip clip)
    {
        _musicSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}
