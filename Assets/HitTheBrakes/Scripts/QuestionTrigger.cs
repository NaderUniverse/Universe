using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    public Question question;

    void Start()
    {
        FindObjectOfType<QuestionManager>().DisplayQuestion();
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<QuestionManager>().DisplayQuestion();
    }
}
