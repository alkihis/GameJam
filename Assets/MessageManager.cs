using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class MessageManager : MonoBehaviour
{
    public MessageBoxFax messageBoxFax;
    public Element currentElement;
    private readonly HashSet<int> usedQuestions = new HashSet<int>();
    public PenguinManager penguinManager;
    public LifeManager lifeManager;
    public GameObject HappySoundContainer;
    public GameObject NormalSoundContainer;
    public GameObject AngrySoundContainer;
    public Gyrophare gyrophare;
    public int NeededGoodAnswers = 10;
    
    [TextArea(3, 10)]
    public string VictoryMessage = "Bravo";
    
    public delegate void OnLose(string reason);
    public event OnLose LooseEvent;

    private void Awake()
    {
        HideDialog();
    }

    // Start is called before the first frame update
    public void BeginQuestions()
    {
        var json = Dialog.dialog;
        int start = Random.Range(0, json.elements.Length);

        usedQuestions.Add(start);

        var q1 = json.elements[start];

        SetElementQuestion(q1);

        ShowDialog();
        PlayNormalSound();
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

    private void ShuffleAnswers(string[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            string temp = list[i];
            int randomIndex = Random.Range(i, list.Length);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    private void SetAnswerText(string[] elements)
    {
        ShuffleAnswers(elements);
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
        messageBoxFax.messageText.alignment = TextAnchor.MiddleCenter;
        messageBoxFax.messageText.fontSize = 22;
    }

    private string GetRealJobName(string meta)
    {
        Debug.Log(meta);
        switch (meta)
        {
            case "hunter":
                return "chasseur";
            case "worker":
                return "ouvrière";
            case "manager":
                return "manager";
            default:
                return "commercial";
        }
    }

    private void SetElementQuestion(Element e)
    {
        penguinManager.SelectPenguin(e.penguin);
        penguinManager.Show();

        messageBoxFax.buttonRestart.gameObject.SetActive(false);
        SetActiveAnswers(true);
        messageBoxFax.buttonNext.gameObject.SetActive(false);

        messageBoxFax.personnageName.text = e.penguinName + ", " + GetRealJobName(e.penguin);
        messageBoxFax.messageText.text = e.question.text;
        messageBoxFax.messageText.alignment = TextAnchor.UpperLeft;
        messageBoxFax.messageText.fontSize = 18;


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
        messageBoxFax.messageText.alignment = TextAnchor.MiddleCenter;
        messageBoxFax.messageText.text = has_lost ? "Vous avez perdu toutes vos vies. Recommencer ?" : VictoryMessage;
    }
    


    public void StartNextQuestion()
    {
        // Select a random element
        var json = Dialog.dialog;
        gyrophare.Hide();

        // Le joueur a perdu
        if (lifeManager.life == 0)
        {
            messageBoxFax.gameObject.SetActive(false);
            penguinManager.Hide();
            LooseEvent(currentElement.tensionType);
            return;
        }

        if (usedQuestions.Count >= NeededGoodAnswers)
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
            PlayNormalSound();
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

        // On perd une vie
        if (answer.tensionLoss < 0)
        {
            Debug.Log("Dimuntion");
            lifeManager.SalutMonPote();
            penguinManager.ModeFURAX();
            PlayAngrySound();
            gyrophare.Show();
        }
        else
        {
            PlayHappySound();
            penguinManager.ModeRELAX();
        }

        if (answer.tensionLoss > 0)
        {
            lifeManager.AllumerLeFeu();
        }

        SetElementNext(answer.message);
    }

    private void PlayRandomSound(GameObject origin)
    {
        var components = origin.GetComponents<AudioSource>();
        if (components.Length > 0)  {
             var index = Random.Range(0, components.Length);
             components[index].Play();   
        }
    }

    private void PlayNormalSound()
    {
        PlayRandomSound(NormalSoundContainer);
    }
    
    private void PlayHappySound()
    {
        PlayRandomSound(HappySoundContainer);
    }

    private void PlayAngrySound()
    {
        PlayRandomSound(AngrySoundContainer);
    }
}
