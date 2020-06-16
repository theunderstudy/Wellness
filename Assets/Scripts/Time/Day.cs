using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day : MonoBehaviour
{

    public int CurrentChoice = 1;
    public int MaxChoice = 4;

    public void StartDay()
    {
        
    }

    
    public bool DayFinished()
    {
        if (CurrentChoice == MaxChoice)
        {
            return true;
        }
        return false;
    }
}
