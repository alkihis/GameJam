using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    public HideCredits hideCredits;
    public MainMenu mainMenu;
    public CommentJouer commentJouer;


    // Start is called before the first frame update
    void Awake()
    {
        hideCredits.gameObject.SetActive(false);
        commentJouer.gameObject.SetActive(false);
    }
}
