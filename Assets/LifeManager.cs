using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    static readonly int START_LIFE = 3;
    protected EventManager eventManager;
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

        if (life == 0)
        {
            Debug.Log("Partie terminée !");
        }
    }

    /// <summary>
    /// This function should increment life.
    /// </summary>
    public void AllumerLeFeu()
    {
        life++;
        eventManager.LifeGained();
    }

    public void Restart()
    {
        life = START_LIFE;
    }
}
