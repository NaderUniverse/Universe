using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private TextMeshProUGUI coinText;
    private int coins = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            instance = this;
            //Destroy(this);
            //return;
        }

        DontDestroyOnLoad(instance);

    }

    public void AddCoin()
    {
        coins++;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        // "Score: " +  Convert.ToString(score) + "/4";
        coinText.text =  "Score: " +  Convert.ToString(coins) + "/4";
    }
}
