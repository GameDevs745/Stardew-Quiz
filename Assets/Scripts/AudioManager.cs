using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public SoundManager[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Reload();
        Reload2();
    }
    public void Reload()
    {
        if (PlayerPrefs.GetInt("muted") == 1)
        {
            musicSource.mute = true;
        }
        else
        {
            musicSource.mute = false;
        }
    }
    public void Reload2()
    {
        if (PlayerPrefs.GetInt("nonmuted") == 1)
            sfxSource.mute = true;
        else
            sfxSource.mute = false;
    }


    public void PlayMusic(string name)
    {
        SoundManager s = Array.Find(musicSounds, x => x.name == name);

        if(s == null)
        {
            Debug.Log("Sound not found.");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();

        }
    }

    public void PlaySound(string name)
    {
        SoundManager s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found.");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }

    }
    public void StopSound(string name)
    {
        SoundManager s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found.");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Stop();

        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
