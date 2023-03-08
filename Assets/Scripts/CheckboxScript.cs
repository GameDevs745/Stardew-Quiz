using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckboxScript : MonoBehaviour
{
    public GameObject[] checkbox;
    public GameObject[] wrongbox;
    private string[] categoryNames = new string[] { "Crops", "Villagers", "Locations", "Items", "Food" };
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<=4;i++)
        {
            if (PlayerPrefs.GetInt(categoryNames[i] + "score") == 1)
                checkbox[i].SetActive(true);
            else
                wrongbox[i].SetActive(true);
        }
    }
}
