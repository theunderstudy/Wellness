using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Day CurrentDay;



    private void Update()
    {
        if (CurrentDay.DayFinished())
        {
            // Start new day

        }
    }

}
