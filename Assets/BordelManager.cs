using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordelManager : MonoBehaviour
{
    public BordelState1 state1;
    public BordelState2 state2;

    public void Hide()
    {
        state1.gameObject.SetActive(false);
        state2.gameObject.SetActive(false);
    }

    public void ShowState1()
    {
        state1.gameObject.SetActive(true);
        state2.gameObject.SetActive(false);
    }

    public void ShowState2()
    {
        state1.gameObject.SetActive(false);
        state2.gameObject.SetActive(true);
    }
}
