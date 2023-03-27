using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CheckboxScript : MonoBehaviour
{
    public GameObject[] checkbox;
    public GameObject[] wrongbox;
    public Button Secret;
    public int check;
    private string[] categoryNames = new string[] { "Crops", "Villagers", "Locations", "Items", "Food", "Secret" };
    // Start is called before the first frame update
    void Start()
    {
        Secret.gameObject.SetActive(false);
        check = 0;
        for(int i = 0; i <= 4; i++)
        {
            if (PlayerPrefs.GetInt(categoryNames[i] + "score") == 1)
            {
                checkbox[i].SetActive(true);
                check++;
            }
            else
                wrongbox[i].SetActive(true);
        }
        if (check == 5)
        {
            Secret.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt(categoryNames[5] + "score") == 2)
                checkbox[5].SetActive(true);
            else
                wrongbox[5].SetActive(true);
       }


    }
}
