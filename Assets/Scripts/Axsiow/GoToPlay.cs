﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToPlay : MonoBehaviour {
    
    // Start is called before the first frame update
    void Start () {
        GetComponent<Button> ().onClick.AddListener (Back);
    }

    private void Back () {
        SceneManager.LoadScene ("MainScene");
    }

}
