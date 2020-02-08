using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogAnswerTrigger : MonoBehaviour
{
    public void TriggerDialogue(Button button)
    {
        FindObjectOfType<MessageManager>().StartNextDialogueAfterAnswer(button);
    }

}
