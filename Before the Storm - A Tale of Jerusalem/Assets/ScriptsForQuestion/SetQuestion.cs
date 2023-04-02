using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class SetQuestion : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textField;
    public TextMeshProUGUI[] myButtons;
    private Question[] questions;
    void Start()
    {
        string[] lines = System.IO.File.ReadAllLines("Assets\\ScriptsForQuestion\\Questions.txt");
        foreach (string line in lines)
        {
            string[] splitString=line.Split('-');
            //string[] answers = null;
            //answers.Append(splitString[1]);
            //answers.Append(splitString[2]);
            //answers.Append(splitString[3]);
            //answers.Append(splitString[4]);
            //Question currentQuestion = new Question(splitString[0], answers, splitString[5]);
            //questions.Append(currentQuestion);
            textField.text = splitString[0];
            myButtons[0].text = splitString[1];
            myButtons[1].text = splitString[2];
            myButtons[2].text = splitString[3];
            myButtons[3].text = splitString[4];
        }
        //textField.text=questions[0].questionText;
        //myButtons[0].text = questions[0].answers[0];
        //myButtons[1].text = questions[0].answers[1];
        //myButtons[2].text = questions[0].answers[2];
        //myButtons[3].text = questions[0].answers[3];
        //textField.text = value;
    }
}
