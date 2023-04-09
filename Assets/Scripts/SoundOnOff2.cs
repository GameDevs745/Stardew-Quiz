using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;

public class SoundOnOff2 : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    public Slider soundSlider;
    public float valueS;
    private bool nonmuted = false;
    void Start()
    {
        if (!PlayerPrefs.HasKey("nonmuted"))
        {
            PlayerPrefs.SetInt("nonmuted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        if (PlayerPrefs.GetInt("FirstTimeSound") != 1)
        {
            soundSlider.value = 0.5f;
            PlayerPrefs.SetInt("FirstTimeSound", 1);
            Save();
            UpdateButtonIcon();
        }
        else
            soundSlider.value = PlayerPrefs.GetFloat("soundSlider");
        if (PlayerPrefs.GetInt("nonmuted") == 1)
        {
            soundSlider.interactable = false;
            nonmuted = true;
            Save();
            UpdateButtonIcon();
        }
        else
        {
            soundSlider.interactable = true;
            nonmuted = false;
            Save();
            UpdateButtonIcon();
            
        }

    }

    public void sound()
    {
        if (nonmuted == false)
        {
            nonmuted = true;
            soundSlider.interactable = false;
        }
        else
        {
            nonmuted = false;
            soundSlider.interactable = true;
        }
        if (soundSlider.value == 0 || nonmuted == true)
        { 
            AudioManager.Instance.ToggleSFX();
            PlayerPrefs.SetInt("nonmuted", 1);         
        }
        Save();
        UpdateButtonIcon();
    }
    public void soundChecker()
    {
        if (soundSlider.value == 0)
        {
            nonmuted = true;
            soundSlider.interactable = false;
            PlayerPrefs.SetInt("nonmuted", 1);
        }
        else
        {
            nonmuted = false;
            soundSlider.interactable = true;
            PlayerPrefs.SetInt("nonmuted", 0);
        }
        Save();
        UpdateButtonIcon();

    }
    private void Load()
    {
        nonmuted = PlayerPrefs.GetInt("nonmuted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("nonmuted", nonmuted ? 1 : 0);
    }
    private void UpdateButtonIcon()
    {
        if (nonmuted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }
    public void CheckerS()
    {
        if (soundSlider.value != 0)
        {
            valueS = soundSlider.value;
            PlayerPrefs.SetFloat("valueS", valueS);
        }
        if (PlayerPrefs.GetInt("nonmuted") == 1)
        {
            soundSlider.value = 0;
            soundSlider.interactable = false;
            PlayerPrefs.SetInt("nonmuted", 1);
        }
        else
        {
            soundSlider.value = PlayerPrefs.GetFloat("valueS");
            soundSlider.interactable = true;
            PlayerPrefs.SetInt("nonmuted", 0);
        }
        Save();
        UpdateButtonIcon();
    }
    public void Update()
    {
        PlayerPrefs.SetFloat("soundSlider", soundSlider.value);


    }
}

