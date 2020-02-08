using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguins : MonoBehaviour
{
    public PenguinHunter hunter;
}

public class Penguin : MonoBehaviour
{
    public Animator all;

    public void Start()
    {
        Enter();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Enter()
    {
        all.Play("Entering");
    }

    public void Out()
    {
        all.Play("Out");
    }

    public void Angry()
    {
        all.Play("Angry");
    }

    public void Happy()
    {
        all.Play("Happy");
    }
}
