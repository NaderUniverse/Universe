using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreAnimation : MonoBehaviour
{
   public TMP_Text score;
   public IEnumerator CorrectAnimation()
    {
        for (int i = 0; i < 41; i++)
        {
            // flash green and white for correct answer
            if (i % 2 == 1)
            {
                score.color = Color.green;
            }
            else
            {
                score.color = Color.white;
            }
            // stop for 0.2 
            yield return new WaitForSeconds(0.2f);
        }
    }

    public IEnumerator WrongAnimation()
    {
        for (int i = 0; i < 25; i++)
        {
            if (i % 2 == 1)
            {
                score.color = Color.red;
            }
            else
            {
                score.color = Color.white;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
