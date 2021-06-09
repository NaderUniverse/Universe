using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoublePulleyVolume : MonoBehaviour
{
    public Slider m_Audio;

    int S_Value;

    // Start is called before the first frame update
    void Start()
    {

       

    }

    // Update is called once per frame
    void Update()
    {

       

        PlayerPrefs.SetInt("Volume", S_Value);

    }
}
