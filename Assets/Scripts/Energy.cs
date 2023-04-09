using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Energy : MonoBehaviour
{
    [SerializeField] Text energyText;
    [SerializeField] Text timerText;
    [SerializeField] Slider energyBar;
    private int maxEnergy = 50;
    private int currentEnergy;
    private int restoreDuration = 1800;
    private DateTime nextEnergyTime;
    private DateTime lastEnergyTime;
    private bool isRestoring = false;

    void Start()
    { 
        if (!PlayerPrefs.HasKey("currentEnergy"))
        {
            PlayerPrefs.SetInt("currentEnergy", 50);
            Load();
            StartCoroutine(RestoreEnergy());
        }
        else
        {
            Load();
            StartCoroutine(RestoreEnergy());
        }
    }
    public void UseEnergy()
    {
        if(currentEnergy >= 10 && PlayerPrefs.GetInt("infiniteEnergy") == 0)
        {
            currentEnergy-=10;
            PlayerPrefs.SetInt("currentEnergy", currentEnergy);

            UpdateEnergy();
            if(isRestoring == false)
            {
                if(currentEnergy + 10 == maxEnergy)
                {
                    nextEnergyTime = AddDuration(DateTime.Now, restoreDuration);
                }
                StartCoroutine(RestoreEnergy());
            }
        }
        else
        {
            Debug.Log("Not enough energy!");
        }
    }
    public void AddEnergy()
    { if (currentEnergy <= maxEnergy && PlayerPrefs.GetInt("infiniteEnergy") == 0)
        {
            currentEnergy += 10;
            UpdateEnergy();
            UpdateEnergyTimer();
            PlayerPrefs.SetInt("currentEnergy", currentEnergy);
            AudioManager.Instance.PlaySound("Click");
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");
    }


    public IEnumerator RestoreEnergy()
    {
        UpdateEnergyTimer();
        isRestoring = true;
        while(currentEnergy < maxEnergy)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime nextDateTime = nextEnergyTime;
            bool isEnergyAdding = false;

            while(currentDateTime > nextDateTime)
            {
                if(currentEnergy < maxEnergy)
                {
                    isEnergyAdding = true;
                    currentEnergy+=10;
                    UpdateEnergy();
                    DateTime timeToAdd = lastEnergyTime > nextDateTime ? lastEnergyTime : nextDateTime;
                    nextDateTime = AddDuration(timeToAdd, restoreDuration);
                }
                else
                {
                    break;
                }
            }
            if(isEnergyAdding == true)
            {
                lastEnergyTime = DateTime.Now;
                nextEnergyTime = nextDateTime;
            }
            UpdateEnergyTimer();
            UpdateEnergy();
            Save();
            yield return null;
        }
        isRestoring = false;
    }
    public DateTime AddDuration(DateTime datetime, int duration)
    {
        return datetime.AddSeconds(duration);
    }
    public void UpdateEnergyTimer()
    {
        if(currentEnergy >= maxEnergy)
        {
            timerText.text = "Full";
            return;
        }
        TimeSpan time = nextEnergyTime - DateTime.Now;
        string timeValue = String.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
        timerText.text = timeValue;
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("infiniteEnergy") == 1)
        {
            timerText.text = "INFINITE";
            currentEnergy = 50;
            PlayerPrefs.SetInt("currentEnergy", currentEnergy);
        }
    }
    public void UpdateEnergy()
    {
        energyText.text = currentEnergy.ToString() + "/" + maxEnergy.ToString();
        energyBar.maxValue = maxEnergy;
        energyBar.value = currentEnergy;
    }
    public DateTime StringToDate(string datetime)
    {
        if (String.IsNullOrEmpty(datetime))
        {
            return DateTime.Now;
        }
        else
        {
            return DateTime.Parse(datetime);
        }
    }
    public void Load()
    {
        currentEnergy = PlayerPrefs.GetInt("currentEnergy");
        nextEnergyTime = StringToDate(PlayerPrefs.GetString("nextEnergyTime"));
        lastEnergyTime = StringToDate(PlayerPrefs.GetString("lastEnergyTime"));
    }
    public void Save()
    {
        PlayerPrefs.SetInt("currentEnergy", currentEnergy);
        PlayerPrefs.SetString("nextEnergyTime", nextEnergyTime.ToString());
        PlayerPrefs.SetString("lastEnergyTime", lastEnergyTime.ToString());
    }
}
