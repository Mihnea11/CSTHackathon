using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
   public string questionText { get; set; }
   public string[] answers { get; set; }
   public string correctAnswer { get; set; } 
   public Question(string newQuestionText, string[] answersForQuestion, string correctAnswer)
   {
       this.questionText = newQuestionText;
       this.answers = answersForQuestion;
       this.correctAnswer = correctAnswer;
   }
}
