using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int life = 3;

    /// <summary>
    /// This function decrement life
    /// and should (TODO) refresh hearts shown in UI.
    ///
    /// If life == 0 at the end, player should die.
    /// </summary>
    public void SalutMonPote()
    {
        life--;

        if (life == 0)
        {
            Debug.Log("Partie terminée !");
        }
    }
}
