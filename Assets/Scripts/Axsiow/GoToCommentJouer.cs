using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToCommentJouer : MonoBehaviour {
    public TitleScreenManager titleScreenManager;

    public void Back() {
        Debug.Log("Activate comment jouer");
        titleScreenManager.commentJouer.gameObject.SetActive(true);
        titleScreenManager.mainMenu.gameObject.SetActive(false);
    }
}
