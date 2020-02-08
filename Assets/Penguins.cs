using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguins : MonoBehaviour
{
    public PenguinHunter hunter;
    public PenguinSeller seller;
    public PenguinColeBlanc coleBlanc;
    public PenguinWorker worker;
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

    public void ModeFURAX()
    {
        all.Play("Angry");
    }

    public void ModeRELAX()
    {
        all.Play("Success");
    }

    public void Talk()
    {
        all.Play("Talking");
    }

    public void Idle()
    {
        all.Play("Idle");
    }
}
