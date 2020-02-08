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

    public void SelectPenguin(string name)
    {
        if (current_penguin)
            Hide();
        current_penguin = penguins.hunter;
    }

    public void Show()
    {
        current_penguin.Enter();
    }

    public void Hide()
    {
        current_penguin.Out();
    }
}
