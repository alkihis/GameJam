using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCommentJouer : MonoBehaviour {
    
    // Start is called before the first frame update
    void Start() {
        GameObject.Find("CommentJouerCanvas").SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
