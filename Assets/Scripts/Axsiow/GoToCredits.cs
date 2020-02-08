using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToCredits : MonoBehaviour{

    // OK BOOMER
    void Start ()
    {
        GetComponent<Button>().onClick.AddListener(Back);
    }

    private void Back ()
    {
        Canvas[] canvases = Resources.FindObjectsOfTypeAll<Canvas>();

        GameObject creditsCanvas = canvases[0].gameObject;
        GameObject mainCanvas = canvases[1].gameObject;
        mainCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
            

        // GameObject mainCanvas = GameObject.Find("Canvas");
        // GameObject creditsCanvas = GameObject.Find("CreditsCanvas");
        // Debug.Log(creditsCanvas.ToString());
        // mainCanvas.SetActive(false);
        // creditsCanvas.SetActive(true);
    }
}
