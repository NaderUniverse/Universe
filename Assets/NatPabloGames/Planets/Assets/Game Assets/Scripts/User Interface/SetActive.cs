using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public void Awake()
    {
        Hide();
    }

    public void ShowQuest()
    {
        gameObject.SetActive(true);
    }

    public void ShowInputUI()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
