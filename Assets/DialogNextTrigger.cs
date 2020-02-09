using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogNextTrigger : MonoBehaviour
{
    public void TriggerDialogue()
    {
        FindObjectOfType<MessageManager>().StartNextQuestion();
    }

}
