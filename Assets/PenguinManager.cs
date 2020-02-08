using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class / GameObject should handle the penguin changes and animations when
/// questions are successfully/badly answered.
/// </summary>
public class PenguinManager : MonoBehaviour
{
    // Define here gameobjects links to penguins.
    public Penguins penguins;

    public Penguin current_penguin;

    void Awake()
    {
        HidePinguins();
    }

    public void HidePinguins()
    {
        penguins.hunter.Hide();
        penguins.worker.Hide();
        penguins.coleBlanc.Hide();
        penguins.seller.Hide();
    }

    public void SelectPenguin(string name)
    {
        if (current_penguin)
        {
            Hide();
            Debug.Log("Hiding the pinguin.");
        }

        Debug.Log(name);
        HidePinguins();

        switch (name)
        {
            case "hunter":
                current_penguin = penguins.hunter;
                break;
            case "worker":
                current_penguin = penguins.worker;
                break;
            case "manager":
                current_penguin = penguins.coleBlanc;
                break;
            case "seller":
                current_penguin = penguins.seller;
                break;
        }

        current_penguin.Show();
    }

    public void Show()
    {
        Debug.Log("Showing the penguin");
        current_penguin.Enter();
    }

    public void Hide()
    {
        current_penguin.Out();
    }

    public void ModeRELAX()
    {
        current_penguin.ModeRELAX();
    }

    public void ModeFURAX()
    {
        current_penguin.ModeFURAX();
    }

    public void Idle()
    {
        current_penguin.Idle();
    }
}
