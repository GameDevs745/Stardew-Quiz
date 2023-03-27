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

    }

    public void sound()
    {
        if (nonmuted == false)
        {
            nonmuted = true;
        }
        else
        {
            nonmuted = false;
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
}

