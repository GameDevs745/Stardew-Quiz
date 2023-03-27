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
    public GameObject soundOnSprite;
    public GameObject soundOffSprite;
    public GameObject musicOnSprite;
    public GameObject musicOffSprite;
    public GameObject soundBtn;
    public GameObject musicBtn;
    public GameObject settingsPanel;
    public int musicInt = 1;
    public int soundInt = 1;
    public float volume = 0;
    void Start()
    {
         PlayerPrefs.GetInt("musicInt", musicInt);
         PlayerPrefs.GetInt("soundInt", soundInt);
    }
    public void music()
    {
        if (musicInt == 1)
        {
            AudioManager.Instance.PlaySound("Click");
            musicOffSprite.SetActive(false);
            musicOnSprite.SetActive(true);
            PlayerPrefs.SetInt("musicInt", 0);
        }
        else
        {
            musicOnSprite.SetActive(false);
            musicOffSprite.SetActive(true);
            PlayerPrefs.SetInt("musicInt", 1);
        }
    }
        public void sound()
        {  
            if (soundInt == 1)
            {
                AudioManager.Instance.PlaySound("Click");
                soundOffSprite.SetActive(false);
                soundOnSprite.SetActive(true);
                PlayerPrefs.SetInt("soundInt", 0);
        }
            else
            {   
                soundOnSprite.SetActive(false);
                soundOffSprite.SetActive(true);
                PlayerPrefs.SetInt("soundInt", 1);
        }
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
    void Update()
    {
        musicInt = PlayerPrefs.GetInt("musicInt");
        soundInt = PlayerPrefs.GetInt("soundInt");
    }

}
