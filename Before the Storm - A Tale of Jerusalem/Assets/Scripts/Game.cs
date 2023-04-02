using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static bool IsFinished { get; private set; }

    [SerializeField]
    private GameObject pointsDisplay;
    [SerializeField]
    private GameObject gate;

    private List<GameObject> questionsGameObjects;
    private List<Quiz> questions;
    private int currentQuestion;

    private void Start()
    {
        FirstPersonController.CanMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        questionsGameObjects = new List<GameObject>();
        questions = new List<Quiz>();
        currentQuestion = 0;

        foreach(Transform childTransform in this.transform)
        {
            questionsGameObjects.Add(childTransform.gameObject);
            questions.Add(childTransform.gameObject.GetComponent<Quiz>());
        }

        questionsGameObjects[currentQuestion].SetActive(true);

        IsFinished = false;
    }

    public void AnswerButtonClick(string answer)
    {
        if(answer != questions[currentQuestion].CorrectAnswer)
        {
            StartCoroutine(WrongAnswer());  
        }
        else
        {
            StartCoroutine(RightAnswer());
        }
    }

    private IEnumerator WrongAnswer()
    {
        questions[currentQuestion].Text.color = Color.red;
        yield return new WaitForSeconds(1f);

        questionsGameObjects[currentQuestion].SetActive(false);
        questions[currentQuestion].Text.color = Color.white;

        currentQuestion++;

        if (currentQuestion >= questionsGameObjects.Count)
        {
            FirstPersonController.CanMove = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            OpenDoor();
        }
        else
        {
            questionsGameObjects[currentQuestion].SetActive(true);
        }
    }

    private IEnumerator RightAnswer()
    {
        questions[currentQuestion].Text.color = Color.green;
        FirstPersonController.Points += 10;
        pointsDisplay.GetComponent<Text>().text = "Points: " + FirstPersonController.Points.ToString();

        yield return new WaitForSeconds(1f);

        questionsGameObjects[currentQuestion].SetActive(false);
        questions[currentQuestion].Text.color = Color.white;

        currentQuestion++;

        if(currentQuestion >= questionsGameObjects.Count)
        {
            FirstPersonController.CanMove = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            OpenDoor();
        }
        else
        {
            questionsGameObjects[currentQuestion].SetActive(true);
        }
    }

    private void OpenDoor()
    {
        if(FirstPersonController.Points > 50)
        {
            gate.GetComponent<Animator>().Play("OpenGateAnimation");
        }
        else
        {
            gate.GetComponent<Animator>().Play("CloseGateAnimation");
        }
    }
}
