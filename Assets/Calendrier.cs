using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendrier : MonoBehaviour
{
    public GameObject[] months;

    public void ShowNumber(int number)
    {
        var go = GetMonth(number);

        if (go != null)
        {
            go.SetActive(true);
        }
    }

    public void HideNumber(int number)
    {
        var go = GetMonth(number);

        if (go != null)
        {
            go.SetActive(false);
        }
    }

    public GameObject GetMonth(int number)
    {
        return months[number - 2];
    }

    public void Reset()
    {
        for (var i = 2; i <= 12; i++)
        {
            HideNumber(i);
        }
    }
}
