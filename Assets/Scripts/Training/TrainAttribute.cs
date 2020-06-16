using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAttribute : MonoBehaviour
{
    Player Player;
    public float TrainAmount = 1;
    private void Start()
    {
        Player = FindObjectOfType<Player>();
    }

    public void StartKnowledgeTrainingSequence()
    {
        ApplyKnowledgeTraining();
    }
    public virtual void ApplyKnowledgeTraining()
    {
        Player.Knowledge.Train(TrainAmount * GetWellnessModifyer()); 
    }
      public void StartWellnessTrainingSequence()
    {
        ApplyWellnessTraining();
    }
    public virtual void ApplyWellnessTraining()
    {
        Player.Wellness.Train(TrainAmount * GetWellnessModifyer());

    }


    public void StartFitnessTrainingSequence()
    {
        ApplyFitnessTraining();
    }
    public virtual void ApplyFitnessTraining()
    {
        Player.Fitness.Train(TrainAmount * GetWellnessModifyer());

    }



    public float GetWellnessModifyer()
    {

        // 0% = 0
        // 50% = 1
        // 100% = 2

        float WellnessPercentage = Player.Wellness.Current / Player.Wellness.Maximum;
        float Modifyer = 1;
        if (WellnessPercentage < 0.5f)
        {
            Modifyer = Mathf.Lerp(0.5f , 1 , WellnessPercentage);
        }
        else
        {
            Modifyer = Mathf.Lerp(1,2, WellnessPercentage);
        }

        return Modifyer;
    }
}
