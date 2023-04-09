using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public void SelectQuiz()
    {
        SceneManager.LoadScene("ChooseQuiz");
        AudioManager.Instance.PlaySound("Click");
    }
    public void HomeScreen()
    {
        PlayerPrefs.SetInt("home", 1);
        PlayerPrefs.SetInt("adInitialized", 1);
        SceneManager.LoadScene("ChooseQuiz");
        AudioManager.Instance.PlaySound("Click");
    }
    public void playCrops()
    {   if(PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
        PlayerPrefs.SetInt("timer", 1);
        SceneManager.LoadScene("Crops");
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.PlayMusic("Music");
        PlayerPrefs.SetInt("home", 0);
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");

    }
    public void playVillagers()
    {
        if (PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
            PlayerPrefs.SetInt("timer", 1);
            SceneManager.LoadScene("Villagers");
            AudioManager.Instance.PlaySound("Click");
            AudioManager.Instance.PlayMusic("Music");
            PlayerPrefs.SetInt("home", 0);
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");

    }
    public void playLocations()
    {
        if (PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
            PlayerPrefs.SetInt("timer", 1);
            SceneManager.LoadScene("Locations");
            AudioManager.Instance.PlaySound("Click");
            AudioManager.Instance.PlayMusic("Music");
            PlayerPrefs.SetInt("home", 0);
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");

    }
    public void playItems()
    {
        if (PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
            PlayerPrefs.SetInt("timer", 1);
            SceneManager.LoadScene("Items");
            AudioManager.Instance.PlaySound("Click");
            AudioManager.Instance.PlayMusic("Music");
            PlayerPrefs.SetInt("home", 0);
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");

    }
    public void playFood()
    {
        if (PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
            PlayerPrefs.SetInt("timer", 1);
            SceneManager.LoadScene("Food");
            AudioManager.Instance.PlaySound("Click");
            AudioManager.Instance.PlayMusic("Music");
            PlayerPrefs.SetInt("home", 0);
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");

    }
    public void playSecret()
    {
        if (PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
            PlayerPrefs.SetInt("timer", 1);
            SceneManager.LoadScene("Secret");
            AudioManager.Instance.PlaySound("Click");
            AudioManager.Instance.PlayMusic("Music");
            PlayerPrefs.SetInt("home", 0);
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");

    }
    public void Back()
    {
        SceneManager.LoadScene("ChooseQuiz");
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.PlayMusic("Music");
    }

}
