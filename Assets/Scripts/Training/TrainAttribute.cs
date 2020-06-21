using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAttribute : MonoBehaviour
{
    Player Player;
    public float TrainAmount = 1;

    public StrengthTraining StrengthTraining;
    public KnowledgeTraining KnowledgeTraining;
    public TrainingGame CurrentTraining;
    public int coffeeMod = 1;
    private Day Dayref;

    public string[] WellnessTexts;
    public string WellnessWarning;

    public GameObject TrainingOptionsUI;
    public GameObject CoffeeButton;
    public float CurrentTrainingTime = 0;
    public bool WellnessTrained = false;
    public bool Warned = false;

    public int FitnessTest = 100;
    public int KnowledgeTest = 100;
    public static TrainAttribute Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Player = FindObjectOfType<Player>();
        Dayref = FindObjectOfType<Day>();
    }

    public void StartKnowledgeTrainingSequence()
    {
        if (CurrentTraining != null)
        {
            return;
        }
        HideTrainingOptions();
        KnowledgeTraining.Present();
       // KnowledgeTraining.Begin();
        CurrentTraining = KnowledgeTraining;
    }

    public void StartWellnessTrainingSequence()
    {
        if (CurrentTraining != null)
        {
            return;
        }

        HideTrainingOptions();
        UIpopup.Instance.DisplayTextPopup(WellnessTexts[Random.Range(0,WellnessTexts.Length)],ResetTraining , true);
        WellnessTrained = true;
    }


    public void StartFitnessTrainingSequence()
    {
        if (CurrentTraining != null)
        {
            return;
        }
        HideTrainingOptions();

        StrengthTraining.Present();
       // StrengthTraining.Begin();
        CurrentTraining = StrengthTraining;
    }

    private void ResetTraining()
    {
        if (WellnessTrained)
        {
            WellnessTrained = false;
            Player.Wellness.Train(Player.Wellness.Maximum);
        }
        CurrentTraining = null;
        CurrentTrainingTime = 0;
        coffeeMod = 1;
        Dayref.PresentResults();
    }

    private void Update()
    {
        if (CurrentTraining != null)
        {
            if (CurrentTraining.bStopped)
            {
                return;
            }
            CurrentTraining.UpdateTraining();
            CurrentTraining.CheckPlayerInput();
            CurrentTrainingTime += Time.deltaTime;
            if (CurrentTrainingTime > CurrentTraining.TrainingLength)
            {
                Warned = false;
                CurrentTraining.EndTraining();
                UIpopup.Instance.DisplayTextPopup("Nice work!! You scored " + CurrentTraining.Score, EndSequence);
            }
        }
    }

    public void EndSequence()
    {

        // bring some UI in?
        CurrentTraining.ApplyTraining();

        CurrentTraining.CleanUp();
        
        ResetTraining();
    }
    public void PresentTrainingOptions()
    {
        TrainingOptionsUI.SetActive(true);
        if (Dayref.DayCount==3 && Dayref.CurrentChoice ==1)
        {
            CoffeeButton.gameObject.SetActive(true);
        }
    }

    public void HideTrainingOptions()
    {
        TrainingOptionsUI.SetActive(false);
        CoffeeButton.gameObject.SetActive(false);

        UIpopup.Instance.DisplayTextPopup("");
    }
    public void CoffeeButtonFunc()
    {
        coffeeMod = 8;
        Player.Wellness.Train(Player.Wellness.Maximum*-1);
    }
    public int GetWellnessModifyer()
    {

        // 0% = 0
        // 50% = 1
        // 100% = 2

        float WellnessPercentage = (float)Player.Wellness.Current / Player.Wellness.Maximum;

        int Modifyer = Mathf.RoundToInt(Mathf.Lerp(1, 5, WellnessPercentage));
        Modifyer *= coffeeMod;

        return Modifyer;
    }
}
