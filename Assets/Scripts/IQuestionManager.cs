using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.VFX;
using TMPro;

public interface IQuestionManager
{

    //Text Variable
    GameObject typingAudio { get; set; }

    TMP_Text questionText { get; set; }
    TMP_InputField input { get; set; }
    TMP_Text scoreText { get; set; }
    TMP_Text answer { get; set; }
    TMP_Text isCorrectText { get; set; }
    string question { get; set; }

    //Feedback variables
    int score { get; set; }
    int total { get; set; }
    GameObject correctAnimation { get; set; }
    GameObject incorrectAnimation { get; set; }
    GameObject answerMenu { get; set; }

    //Function prototype
    void DisplayQuestion();
    void EnterAnswer();
    void StopAnimations();
    void StartCorrectAnimations();
    void StartWrongAnimations();
    IEnumerator TypeQuestion(string question);
    


}
