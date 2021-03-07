using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string name;

    [TextArea(3, 10)]
    public string[] questions;
}
