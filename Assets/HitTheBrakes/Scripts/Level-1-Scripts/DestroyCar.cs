﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCar : MonoBehaviour
{
    // Start is called before the first frame update
    public void Remove()
    {
        Destroy(gameObject);
    }

}
