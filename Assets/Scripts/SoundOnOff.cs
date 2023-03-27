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

    }

    public void music()
    {
        if (muted == false)
        {
            muted = true;
        }
        else
        {
            muted = false;
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
            musicOffIcon.enabled =false;
        }
        else
        {
            musicOnIcon.enabled = false;
            musicOffIcon.enabled = true;
        }
    }

    public void sound()
        {  
           
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
}
