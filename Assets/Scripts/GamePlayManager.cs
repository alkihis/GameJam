using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{

    public GameObject IntroCanvas;
    public GameObject NewsPapers;
    public MessageManager messages;

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
    }

    public void StartCameraPan()
    {
        Debug.Log("Pan camera");
        Camera.main.gameObject.GetComponent<Animator>().SetTrigger("PanTrigger");
        // Wait for it to finish ... ?
    }

    void StartPaperFall()
    {
        NewsPapers.GetComponent<Animator>().SetTrigger("FallTrigger");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
