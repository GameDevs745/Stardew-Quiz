using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SelectQuiz()
    {
        SceneManager.LoadScene("ChooseQuiz");
        AudioManager.Instance.PlaySound("Click");
    }
    public void HomeScreen()
    {
        SceneManager.LoadScene("MainMenu");
        AudioManager.Instance.PlaySound("Click");
    }
    public void playCrops()
    {   if(PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
        SceneManager.LoadScene("Crops");
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.PlaySound("Music");
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");

    }
    public void playVillagers()
    {
        if (PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
            SceneManager.LoadScene("Villagers");
            AudioManager.Instance.PlaySound("Click");
            AudioManager.Instance.PlaySound("Music");
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");

    }
    public void playLocations()
    {
        if (PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
            SceneManager.LoadScene("Locations");
            AudioManager.Instance.PlaySound("Click");
            AudioManager.Instance.PlaySound("Music");
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");

    }
    public void playItems()
    {
        if (PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
            SceneManager.LoadScene("Items");
            AudioManager.Instance.PlaySound("Click");
            AudioManager.Instance.PlaySound("Music");
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");

    }
    public void playFood()
    {
        if (PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
            SceneManager.LoadScene("Food");
            AudioManager.Instance.PlaySound("Click");
            AudioManager.Instance.PlaySound("Music");
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");

    }
    public void playSecret()
    {
        if (PlayerPrefs.GetInt("currentEnergy") >= 10)
        {
            SceneManager.LoadScene("Secret");
            AudioManager.Instance.PlaySound("Click");
            AudioManager.Instance.PlaySound("Music");
        }
        else
            AudioManager.Instance.PlaySound("Incorrect");

    }
    public void Back()
    {
        SceneManager.LoadScene("ChooseQuiz");
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.StopSound("Music");
    }

}
