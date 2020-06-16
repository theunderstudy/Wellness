using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AttributeDisplay : MonoBehaviour
{
    private Player Player;
    public Image KnowledgeDisplay;
    private float CurrentKnowledge = -15;
    public Image FitnessDisplay;
    private float CurrentFitness = -15;
    public Image WellnessDisplay;
    private float CurrentWellness = -15;

    public float EaseTime = 0.75f;
    public Ease FillEase = Ease.OutQuad;
    private void Start()
    {
        Player = FindObjectOfType<Player>();
    }
    void Update()
    {
        // Knowledge
        if (Player.Knowledge.Current != CurrentKnowledge)
        {
            Attribute CurrentAt = Player.Knowledge;
            CurrentKnowledge = CurrentAt.Current;
            DOTween.Kill(KnowledgeDisplay.GetInstanceID());
            KnowledgeDisplay.DOFillAmount(((float)CurrentAt.Current / CurrentAt.Maximum), EaseTime).SetEase(FillEase).SetId(KnowledgeDisplay.GetInstanceID());
        }
        // Fitness
        if (Player.Fitness.Current != CurrentFitness)
        {
            Attribute CurrentAt = Player.Fitness;
            CurrentFitness = CurrentAt.Current;
            DOTween.Kill(FitnessDisplay.GetInstanceID());
            FitnessDisplay.DOFillAmount(((float)CurrentAt.Current / CurrentAt.Maximum), EaseTime).SetEase(FillEase).SetId(FitnessDisplay.GetInstanceID());
        }
        // Wellbeing
        if (Player.Knowledge.Current != CurrentWellness)
        {
            Attribute CurrentAt = Player.Wellness;
            CurrentWellness = CurrentAt.Current;
            DOTween.Kill(WellnessDisplay.GetInstanceID());
            WellnessDisplay.DOFillAmount(((float)CurrentAt.Current / CurrentAt.Maximum), EaseTime).SetEase(FillEase).SetId(WellnessDisplay.GetInstanceID());
        }
    }
}
