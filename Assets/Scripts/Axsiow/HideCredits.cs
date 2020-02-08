using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCredits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("CreditsCanvas").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
