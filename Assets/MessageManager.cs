using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MessageManager : MonoBehaviour
{
    public MessageBoxFax messageBoxFax;
    public Element currentElement;
    private readonly HashSet<int> usedQuestions = new HashSet<int>();
    public PenguinManager penguinManager;
    public LifeManager lifeManager;

    private void Awake()
    {
        HideDialog();
    }

    // Start is called before the first frame update
    void Start()
    {
        var json = Dialog.dialog;
        int start = Random.Range(0, json.elements.Length);

        usedQuestions.Add(start);

        var q1 = json.elements[start];

        SetElementQuestion(q1);

        penguinManager.SelectPenguin("");

        penguinManager.Show();

        ShowDialog();
    }

    void HideDialog()
    {
        messageBoxFax.gameObject.SetActive(false);
    }

    void ShowDialog()
    {
        messageBoxFax.gameObject.SetActive(true);
    }

    private void SetActiveAnswers(bool be_active)
    {
        messageBoxFax.answerOne.gameObject.SetActive(true);
        messageBoxFax.answerTwo.gameObject.SetActive(true);
        messageBoxFax.answerThree.gameObject.SetActive(true);
        messageBoxFax.answerFour.gameObject.SetActive(true);

        messageBoxFax.answerOne.interactable = be_active;
        messageBoxFax.answerTwo.interactable = be_active;
        messageBoxFax.answerThree.interactable = be_active;
        messageBoxFax.answerFour.interactable = be_active;
        SetAnswerText(new string[] { "", "", "", "" });
    }

    private void HideAnswers()
    {
        messageBoxFax.answerOne.gameObject.SetActive(false);
        messageBoxFax.answerTwo.gameObject.SetActive(false);
        messageBoxFax.answerThree.gameObject.SetActive(false);
        messageBoxFax.answerFour.gameObject.SetActive(false);
    }

    private void SetAnswerText(string[] elements)
    {
        // Don't ask, it works
        if (elements.Length < 4)
        {
            messageBoxFax.answerThree.interactable = false;
        }
        if (elements.Length < 3)
        {
            messageBoxFax.answerOne.interactable = false;
        }

        messageBoxFax.answerTwoText.text = elements[0];
        messageBoxFax.answerFourText.text = elements[1];
        if (elements.Length > 2)
        {
            messageBoxFax.answerOneText.text = elements[2];
        }
        if (elements.Length > 3)
        {
            messageBoxFax.answerThreeText.text = elements[3];
        }
    }

    private void SetElementNext(string s)
    {
        messageBoxFax.buttonRestart.gameObject.SetActive(false);
        SetActiveAnswers(false);
        messageBoxFax.buttonNext.gameObject.SetActive(true);
        HideAnswers();

        messageBoxFax.messageText.text = s;
    }

    private void SetElementQuestion(Element e)
    {
        messageBoxFax.buttonRestart.gameObject.SetActive(false);
        SetActiveAnswers(true);
        messageBoxFax.buttonNext.gameObject.SetActive(false);

        messageBoxFax.personnageName.text = e.penguinName;
        messageBoxFax.messageText.text = e.question.text;   

         
        SetAnswerText(e.question.answers.Select(el => el.text).ToArray());

        currentElement = e;
    }

    private void SetElementRestart(bool has_lost = true)
    {
        HideAnswers();

        messageBoxFax.buttonRestart.gameObject.SetActive(true);
        messageBoxFax.buttonNext.gameObject.SetActive(false);

        messageBoxFax.personnageName.text = has_lost ?
            "Perdu :(" :
            "Bravo !";
        messageBoxFax.messageText.text = has_lost ?
            "Vous avez perdu toutes vos vies. Recommencer ?" :
            "Il ne reste plus aucune question. Vous avez réussi à garder toutes vos vies !";
    }


    public void StartNextQuestion()
    {
        // Select a random element
        var json = Dialog.dialog;

        // Le joueur a perdu
        if (lifeManager.life == 0)
        {
            SetElementRestart(true);
            return;
        }

        if (usedQuestions.Count == json.elements.Length)
        {
            // Questions are over !
            Debug.Log("No more questions available !");
            SetElementRestart(false);
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

    /// <summary>
    /// This is called when an answer is selected, this should show answer.message message and dimunate the score tension.
    /// </summary>
    /// <param name="button"></param>
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

        if (answer == null)
        {
            Debug.Log("This should not append.");
            throw new System.Exception("Unexpected answer");
        }
        else
        {
            // On perd une vie
            if (answer.tensionLoss < 0)
            {
                Debug.Log("Dimuntion");
                lifeManager.SalutMonPote();
            }

            SetElementNext(answer.message);
        }
    }

    public void RestartGame()
    {
        usedQuestions.Clear();
        lifeManager.Restart();
        Start();
    }
}
