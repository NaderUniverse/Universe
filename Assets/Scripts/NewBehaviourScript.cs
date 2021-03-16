using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, IQuestionManager
{
    private int myVar;

    public int MyProperty
    {
        get { return myVar; }
        set { myVar = value; }
    }

    public GameObject typingAudio { get; set; }
    public TMP_Text questionText { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public TMP_InputField input { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public TMP_Text scoreText { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public TMP_Text answer { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public TMP_Text isCorrectText { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public string question { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int score { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int total { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public GameObject correctAnimation { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public GameObject incorrectAnimation { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public GameObject answerMenu { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void DisplayQuestion()
    {
        throw new System.NotImplementedException();
    }

    public void EnterAnswer()
    {
        throw new System.NotImplementedException();
    }

    public void StartCorrectAnimations()
    {
        throw new System.NotImplementedException();
    }

    public void StartWrongAnimations()
    {
        throw new System.NotImplementedException();
    }

    public void StopAnimations()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator TypeQuestion(string question)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
