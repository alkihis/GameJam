using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public TextAsset jsonFile;
    public static DialogJson dialog;

    private void Awake()
    {
        dialog = JsonUtility.FromJson<DialogJson>(jsonFile.text);
    }
}
