using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    public HideCredits hideCredits;
    public MainMenu mainMenu;


    // Start is called before the first frame update
    void Awake()
    {
        hideCredits.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
