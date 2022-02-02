using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource soundMusic;
    public AudioSource soundEffect;
    
    public SoundType[] arrayofSounds;
    public bool isMute = false;
    public float Volume = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;                                         // setting levelmanager to the current instance
            DontDestroyOnLoad(gameObject);                          //  we dont want to destroy our levelmanager
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(Sounds.Music);
    }

    public void Mute(bool _status)
    {
        isMute = _status;
    }

    public void SetVolume(float _volume)
    {
        Volume = _volume;
        soundEffect.volume = Volume;
        soundMusic.volume = Volume;
    }
    public void PlayMusic(Sounds _sound)
    {
        if (isMute)
            return;

        AudioClip clip = getSoundClip(_sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.Log("no audio found for sound type " + _sound);
        }
    }
    public void Play(Sounds _sound)
    {
        if (isMute)
            return;

        AudioClip clip = getSoundClip(_sound);
        if(clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("no audio found for sound type " + _sound);            
        }
    }

    private AudioClip getSoundClip(Sounds _sound)
    {
        SoundType sound = Array.Find(arrayofSounds, item => item.soundType == _sound);
        if(sound != null)
        {
            return sound.soundClip;
        }
        return null;

    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    ButtonClick,
    Music,
    PlayerMove,
    PlayerDeath,
    EnemyDeath
}