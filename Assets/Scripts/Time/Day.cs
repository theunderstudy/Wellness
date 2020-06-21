using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day : MonoBehaviour
{

    public int CurrentChoice = 1;
    public int MaxChoice = 4;
    private GameManager GM;
    private TrainAttribute TrainingOptions;

    public int DayCount = 1;

    public int MaxDays = 7;

    public string[] StartOfDayTexts;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        TrainingOptions = FindObjectOfType<TrainAttribute>();
    }

    public void ResetDay()
    {
        DayCount += 1;
        // Reset time
        CurrentChoice = 1;
        
    }

    public void BeginDaySection()
    {
        if (DayCount == MaxDays)
        {
            GM.CheckGameover();
            return;
        }
        if (CurrentChoice ==1)
        {
            UIpopup.Instance.DisplayTextPopup(StartOfDayTexts[ DayCount]);

        }
        // Present training
        TrainingOptions.PresentTrainingOptions();
    }

    public void PresentResults()
    {
        // present training results

        // Then end day

        // probably some dialogue display with end day as a CB
        EndDaySection();
    }

    public void EndDaySection()
    {
        CurrentChoice += 1;
        if (DayFinished())
        {
            ResetDay();
        }


        
        BeginDaySection();

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
