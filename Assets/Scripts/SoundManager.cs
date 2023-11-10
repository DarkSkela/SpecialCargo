using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public Sound[] allSfx;
    public Sound[] allMusic;

    [SerializeField] private AudioSource EffectsSource;
    [SerializeField] private AudioSource MusicSource;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        SetAllSfx();
        SetAllMusic();
       // PlayMusic("BGM");
    }

    public void SetSFXVolume(float value)
    {
        EffectsSource.volume = value;
    }

    public void SetMusicVolume(float value)
    {
        MusicSource.volume = value;

    }

    //public void PlayHover()
    //{
    //    ExtraAudioSource.ignoreListenerPause = true;
    //    PlayExtraAudio("Hover", ExtraAudioSource);
    //}
    //public void PlayClick()
    //{
    //    ExtraAudioSource.ignoreListenerPause = true;
    //    PlayExtraAudio("Click", ExtraAudioSource);
    //}
    void SetAllSfx()
    {
        foreach (Sound sound in allSfx)
        {
            sound.source = EffectsSource; //gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }
    void SetAllMusic()
    {
        foreach (Sound sound in allMusic)
        {
            sound.source = MusicSource; //gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    void SetExtras(Sound sound, AudioSource _aS)
    {

        sound.source = _aS;
        sound.source.clip = sound.clip;

        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
        sound.source.loop = sound.loop;

    }
    void SetMusicandSfx(Sound sound, AudioSource _aS)
    {
        sound.source = _aS;
        _aS.clip = sound.clip;
        _aS.volume = sound.volume;
        _aS.pitch = sound.pitch;
        _aS.loop = sound.loop;
    }


    public void StopSfx()
    {
        EffectsSource.Stop();
    }
    public void StopMusic()
    {
        MusicSource.Stop();
    }


    public void PlaySfx(string name)
    {
        Sound snd = Array.Find(allSfx, sound => sound.name == name);
        SetMusicandSfx(snd, EffectsSource);
        try
        {
            snd.source.Play();
        }
        catch (Exception e)
        {
            Debug.LogWarning("sfx not found");
        }
    }
    public void PlayMusic(string name)
    {
        Sound snd = Array.Find(allMusic, sound => sound.name == name);
        SetMusicandSfx(snd, MusicSource);
        try
        {
            snd.source.Play();
        }
        catch (Exception e)
        {
            Debug.LogWarning("music not found");
        }
    }
}
