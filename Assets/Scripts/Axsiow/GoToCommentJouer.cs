using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToCommentJouer : MonoBehaviour {

    // OK BOOMER
    void Start () {
        GetComponent<Button> ().onClick.AddListener (Back);
    }

    private void Back () {
        Canvas[] canvases = Resources.FindObjectsOfTypeAll<Canvas> ();

        GameObject CommentJouerCanvas = canvases[0].gameObject;
        Debug.Log (canvases[0].ToString());
        GameObject mainCanvas = canvases[2].gameObject;
        Debug.Log (canvases[2].ToString());
        mainCanvas.SetActive (false);
        CommentJouerCanvas.SetActive (true);


        // GameObject mainCanvas = GameObject.Find("Canvas");
        // GameObject creditsCanvas = GameObject.Find("CreditsCanvas");
        // Debug.Log(creditsCanvas.ToString());
        // mainCanvas.SetActive(false);
        // creditsCanvas.SetActive(true);
    }
}
