using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuizManagerScript : MonoBehaviour {

    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private Text falseAnswerText;

    [SerializeField]
    private Text trueAnswerText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    [SerializeField]
    private Animator animator;

    private int countCorrect;

    public GameObject menuQuizThisClass;

    // Use this for initialization
    void Start () {
		if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        SetCurrentQuestion();
        Debug.Log(currentQuestion.fact + " is "+ currentQuestion.isTrue);
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions [randomQuestionIndex];

        factText.text = currentQuestion.fact;

        if (currentQuestion.isTrue)
        {
            trueAnswerText.text = "Correct";
            falseAnswerText.text = "Wrong";
        }
        else
        {
            trueAnswerText.text = "Wrong";
            falseAnswerText.text = "Correct";
        }
    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestions);

        //Change to go to next index in the array!!!!!
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            Debug.Log("Empty Array");
            //unansweredQuestions = questions.ToList<Question>();
        }
        
        SetCurrentQuestion();
    }

    public void UserSelectsTrue()
    {
        animator.SetTrigger("true");
        if (currentQuestion.isTrue)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectsFalse()
    {
        animator.SetTrigger("false");
        if (!currentQuestion.isTrue)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    // Update is called once per frame
    void Update () {
		
	}
}
