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
    { if(PlayerPrefs.GetInt("currentEnergy") >= 10)
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
        SceneManager.LoadScene("Villagers");
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.PlaySound("Music");

    }
    public void playLocations()
    {
        SceneManager.LoadScene("Locations");
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.PlaySound("Music");

    }
    public void playItems()
    {
        SceneManager.LoadScene("Items");
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.PlaySound("Music");

    }
    public void playFood()
    {
        SceneManager.LoadScene("Food");
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.PlaySound("Music");

    }
    public void playSecret()
    {
        SceneManager.LoadScene("Secret");
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.PlaySound("Music");

    }
    public void Back()
    {
        SceneManager.LoadScene("ChooseQuiz");
        AudioManager.Instance.PlaySound("Click");
        AudioManager.Instance.StopSound("Music");
    }

}
