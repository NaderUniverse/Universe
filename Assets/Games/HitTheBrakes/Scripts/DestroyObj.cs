using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public GameObject Object;

    public void DestroyObject()
    {
        Destroy(Object);
    }
}
