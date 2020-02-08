using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMenu : MonoBehaviour {
    
    // OK BOOMER
    void Start () {
        GetComponent<Button> ().onClick.AddListener (Back);
    }

    private void Back () {
        Canvas[] canvases = Resources.FindObjectsOfTypeAll<Canvas>();

        GameObject creditsCanvas = canvases[0].gameObject;
        GameObject mainCanvas = canvases[1].gameObject;
        creditsCanvas.SetActive(false);
        mainCanvas.SetActive(true);

    }
}
