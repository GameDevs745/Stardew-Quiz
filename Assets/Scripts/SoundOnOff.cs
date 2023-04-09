using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;

public class SoundOnOff : MonoBehaviour
{
    [SerializeField] Image musicOnIcon;
    [SerializeField] Image musicOffIcon;
    public GameObject settingsPanel;
    public Slider musicSlider;
    public float valueM;
    private bool muted = false;
    void Start()
    {
         if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        { 
            Load();
        }
        UpdateButtonIcon();
        if (PlayerPrefs.GetInt("FirstTimeMusic") != 1)
        {
            musicSlider.value = 0.5f;
            PlayerPrefs.SetInt("FirstTimeMusic", 1);
            Save();
            UpdateButtonIcon();
        }
        else
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicSlider");
            Save();
            UpdateButtonIcon();
        }
        if (PlayerPrefs.GetInt("muted") == 1)
        {
            musicSlider.interactable = false;
            muted = true;
            Save();
            UpdateButtonIcon();
        }
        else
        {
            musicSlider.interactable = true;
            muted = false;
            Save();
            UpdateButtonIcon();
            
        }



    }
    public void music()
    {
        if (muted == false)
        {
            muted = true;
            musicSlider.interactable = false;
        }
        else
        {
            muted = false;
            musicSlider.interactable = true;
        }
        if (musicSlider.value == 0 || muted == true)
        {
            AudioManager.Instance.ToggleMusic();
            PlayerPrefs.SetInt("muted", 1);
        }
        Save();
        UpdateButtonIcon();

    }
    public void musicChecker()
    {   if (musicSlider.value == 0)
        {
            muted = true;
            musicSlider.interactable = false;
            PlayerPrefs.SetInt("muted", 1);
        }
        else
        {
            muted = false;
            musicSlider.interactable = true;
            PlayerPrefs.SetInt("muted", 0);
        }
        Save();
        UpdateButtonIcon();

    } 
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            musicOnIcon.enabled = true;
            musicOffIcon.enabled = false;
        }
        else
        {
            musicOnIcon.enabled = false;
            musicOffIcon.enabled = true;
        }
    }
    public void CheckerM()
    {
        if (musicSlider.value != 0)
        {
            valueM = musicSlider.value;
            PlayerPrefs.SetFloat("valueM", valueM);
        }
        if (PlayerPrefs.GetInt("muted") == 1)
        {
            musicSlider.value = 0;
            musicSlider.interactable = false;
            PlayerPrefs.SetInt("muted", 1);
        }
        else 
        {
            musicSlider.value = PlayerPrefs.GetFloat("valueM");
            musicSlider.interactable = true;
            PlayerPrefs.SetInt("muted", 0);
        }
        Save();
        UpdateButtonIcon();
    }

    public void settingsOn()
    {
        AudioManager.Instance.PlaySound("Click");
        settingsPanel.SetActive(true);
    }
    public void settingsOff()
    {
        AudioManager.Instance.PlaySound("Click");
        settingsPanel.SetActive(false);
    }
    public void Update()
    {   
        PlayerPrefs.SetFloat("musicSlider", musicSlider.value);
    }
    public void resetSound()
    {   
        AudioManager.Instance.ToggleMusic();
        AudioManager.Instance.ToggleSFX();
    }
}
