using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMenu : MonoBehaviour {
    
    // OK BOOMER
    void Start () {
        GetComponent<Button>().onClick.AddListener(Back);
    }

    private void Back () {
        Canvas[] canvases = Resources.FindObjectsOfTypeAll<Canvas>();

        GameObject CreditsCanvas = canvases[0].gameObject;
        GameObject mainCanvas = canvases[1].gameObject;
        CreditsCanvas.SetActive(false);
        mainCanvas.SetActive(true);

    }
}
