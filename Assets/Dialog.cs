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

        Debug.Log(dialog);

        foreach (var e in dialog.elements)
        {
            Debug.Log("Found question: " + e.question.text);
            foreach (var a in e.question.answers)
            {
                Debug.Log("Found answer: " + a.text);
            }
        }
    }
}
