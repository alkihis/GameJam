using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMenuTwo : MonoBehaviour {
    
    // OK BOOMER
    void Start () {
        GetComponent<Button> ().onClick.AddListener (Back);
    }

    private void Back () {
        Canvas[] canvases = Resources.FindObjectsOfTypeAll<Canvas> ();

        GameObject CommentJouerCanvas = canvases[0].gameObject;
        GameObject mainCanvas = canvases[2].gameObject;
        CommentJouerCanvas.SetActive (false);
        mainCanvas.SetActive (true);

    }
}
