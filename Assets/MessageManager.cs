using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public MessageBoxFax messageBoxFax;
    public Element currentElement;
    private readonly HashSet<int> usedQuestions = new HashSet<int>();

    // Start is called before the first frame update
    void Start()
    {
        var json = Dialog.dialog;
        int start = Random.Range(0, json.elements.Length);

        usedQuestions.Add(start);

        var q1 = json.elements[start];

        SetElementQuestion(q1);
    }

    private void SetElementNext(string s)
    {
        messageBoxFax.buttonRestart.gameObject.SetActive(false);
        messageBoxFax.answerOne.gameObject.SetActive(false);
        messageBoxFax.answerTwo.gameObject.SetActive(false);
        messageBoxFax.buttonNext.gameObject.SetActive(true);

        messageBoxFax.messageText.text = s;
    }

    private void SetElementQuestion(Element e)
    {
        messageBoxFax.buttonRestart.gameObject.SetActive(false);
        messageBoxFax.answerOne.gameObject.SetActive(true);
        messageBoxFax.answerTwo.gameObject.SetActive(true);
        messageBoxFax.buttonNext.gameObject.SetActive(false);

        messageBoxFax.personnageName.text = e.penguinName;
        messageBoxFax.messageText.text = e.question.text;
        messageBoxFax.answerOneText.text = e.question.answers[0].text;
        messageBoxFax.answerTwoText.text = e.question.answers[1].text;

        currentElement = e;
    }

    
    public void StartNextQuestion()
    {
        // Select a random element
        var json = Dialog.dialog;

        if (usedQuestions.Count == json.elements.Length)
        {
            // Questions are over !
            Debug.Log("No more questions available !");
        }
        else
        {
            int start = Random.Range(0, json.elements.Length);

            while (usedQuestions.Contains(start))
            {
                start = Random.Range(0, json.elements.Length);
            }

            usedQuestions.Add(start);
            SetElementQuestion(json.elements[start]);
        }
    }

    /** This is called when an answer is selected, this should show answer.message message and dimunate the score tension. */
    public void StartNextDialogueAfterAnswer(Button button)
    {
        var e = currentElement;

        // Find selected answer
        Answer answer = null;
        var text = button.GetComponentInChildren<Text>();

        foreach (var a in e.question.answers)
        {
            if (a.text.Equals(text.text))
            {
                answer = a;
            }
        }

        // TODO diminuate score tension

        if (answer == null)
        {
            Debug.Log("This should not append.");
            throw new System.Exception("Unexpected answer");
        }
        else
        {
            SetElementNext(answer.message);
        }
    }
}
