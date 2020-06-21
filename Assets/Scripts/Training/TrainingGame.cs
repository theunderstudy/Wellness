using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrainingGame : MonoBehaviour
{
    public int Score = 0;
    public float TrainingLength = 30;
    protected TrainAttribute TrainAtt;
    protected Player player;

    public bool bStopped = false;

    public float MinTimeBetweenSpawns, MaxTimeBetweenSpawns, TimeMulti = 0.9f;
    protected float CurrentTimeBetweenSpawns = 0;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        TrainAtt = FindObjectOfType<TrainAttribute>();
    }
    public abstract void Present();
    public abstract void Begin();
    public abstract void UpdateTraining();
    public abstract void CheckPlayerInput();
    public abstract void EndTraining();
    public abstract void ApplyTraining();
    public abstract void CleanUp();

}
