using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimeDisplay : MonoBehaviour
{
    public Image ClockSprite;
    int currentTod = 0;
    public Image DayBar;
    int currentDay=0;
    private Day day;
    private void Start()
    {
        day = FindObjectOfType<Day>();
    }

    private void Update()
    {
        if (currentTod != day.CurrentChoice)
        {
            currentTod = day.CurrentChoice;
            ClockSprite.DOFillAmount((float) day.CurrentChoice / day.MaxChoice  , 0.35f).SetEase(Ease.OutBack);
        }
        if (currentDay != day.DayCount)
        {
            currentDay = day.DayCount;

            DayBar.DOFillAmount((float)day.DayCount / day.MaxDays, 0.35f).SetEase(Ease.OutSine);

        }

    }
}
