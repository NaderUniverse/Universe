using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlphaScript : MonoBehaviour
{
    public TextMeshProUGUI data;

    // Start is called before the first frame update
    void Start()
    {
        data.text = "α = 90° - Θ";
    }
}
