﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
   public Slider _musicSlider, _sfxSlider;

   public void ToggleMusic()
    {
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    { 
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
}
