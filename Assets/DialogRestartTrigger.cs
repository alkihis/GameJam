using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogRestartTrigger : MonoBehaviour
{
    public void TriggerDialogue()
    {
        FindObjectOfType<MessageManager>().RestartGame();
    }

}
