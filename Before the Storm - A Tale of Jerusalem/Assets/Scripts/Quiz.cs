using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField]
    private string correctAnswer;
    [SerializeField]
    private Text quizText;

    public string CorrectAnswer
    {
        get { return correctAnswer; } 
        set {  correctAnswer = value; }
    }

    public Text Text
    { 
        get { return quizText; }
        set {  quizText = value; }
    }
}
