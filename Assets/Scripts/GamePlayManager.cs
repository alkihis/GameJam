using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{

    public GameObject IntroCanvas;
    public GameObject NewsPaper;
    public MessageManager messages;
    public GameObject MainAudioSource;
    public GameObject GameOverAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        IntroCanvas.SetActive(true);
        var btn = GameObject.Find("OkButton");
        btn.GetComponent<Button>().onClick.AddListener(() =>
        {
            IntroCanvas.SetActive(false);
            // Start game here
            messages.BeginQuestions();
            //StartPaperFall();
        });

        messages.LooseEvent += StartPaperFall;
        messages.LooseEvent += SwitchMusic;
    }

    public void SwitchMusic(string _)
    {
        MainAudioSource.GetComponent<AudioSource>().Stop();
        GameOverAudioSource.GetComponent<AudioSource>().Play();
    }


    public void StartCameraPan()
    {
        Debug.Log("Pan camera");
        Camera.main.gameObject.GetComponent<Animator>().SetTrigger("PanTrigger");
        // Wait for it to finish ... ?
    }

    void StartPaperFall(string reason)
    {
        // Also change musics
        var objectName = "IdentityTensions";
        switch (reason)
        {
            case "performance": 
                objectName = "PerformanceTensions";
                break;
            case "organisation": 
                objectName = "OrganisationTensions";
                break;
            case "apprentissage":
                objectName = "LearningTensions";
                break;
            default:
                objectName = "IdentityTensions";
                break;
        }

        var sprite = GameObject.Find(objectName);
        Debug.Log(sprite);
        if (sprite != null)
        {
            Debug.Log("Enabling");
            sprite.GetComponent<SpriteRenderer>().enabled = true;
        }
        
        NewsPaper.GetComponent<Animator>().SetTrigger("FallTrigger");

        // TODO déclencher la bonne animation de newspaper
    }


    
    // Update is called once per frame
    void Update()
    {
        
    }
}
