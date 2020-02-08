using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMenu : MonoBehaviour {
    public TitleScreenManager titleScreenManager;

    public void Back () {
        titleScreenManager.mainMenu.gameObject.SetActive(true);
        // titleScreenManager.commentJouer.gameObject.SetActive(false);
        titleScreenManager.hideCredits.gameObject.SetActive(false);
    }
}
