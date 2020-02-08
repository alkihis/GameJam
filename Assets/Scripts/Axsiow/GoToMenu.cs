﻿using System.Collections;
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
        SceneManager.LoadScene ("MainMenu");
    }
}
