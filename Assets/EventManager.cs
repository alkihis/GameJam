using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public delegate void LifeGainedAction();
    public static event LifeGainedAction OnLifeGained;

    public delegate void LifeLostAction();
    public static event LifeLostAction OnLifeLost;


    public void LifeGained()
    {
        OnLifeGained?.Invoke();
    }

    public void LifeLost()
    {
        OnLifeLost?.Invoke();
    }
}
