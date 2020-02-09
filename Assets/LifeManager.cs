using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    static readonly int START_LIFE = 3;
    public EventManager eventManager;
    public BordelManager bordelManager;
    public int life = START_LIFE;

    /// <summary>
    /// This function decrement life
    /// and should (TODO) refresh hearts shown in UI.
    ///
    /// If life == 0 at the end, player should die.
    /// </summary>
    public void SalutMonPote()
    {
        life--;
        eventManager.LifeLost();
        RefreshBordelState();

        if (life <= 0)
        {
            Debug.Log("Partie terminée !");
        }
    }

    private void RefreshBordelState()
    {
        if (life <= 1)
        {
            bordelManager.ShowState2();
        }
        else if (life == 2)
        {
            bordelManager.ShowState1();
        }
        else if (life >= 3)
        {
            bordelManager.Hide();
        }
    }

    /// <summary>
    /// This function should increment life.
    /// </summary>
    public void AllumerLeFeu()
    {
        life++;
        eventManager.LifeGained();
        RefreshBordelState();
    }

    public void Restart()
    {
        life = START_LIFE;
    }
}
