using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToCommentJouer : MonoBehaviour {
    public TitleScreenManager titleScreenManager;

    public void Back () {
        Debug.Log("Activate comment jouer");
        titleScreenManager.mainMenu.gameObject.SetActive(false);
        titleScreenManager.hideCredits.gameObject.SetActive(false);
        //titleScreenManager.commentJouer.gameObject.SetActive(true);
    }
}
