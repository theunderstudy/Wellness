using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthTraining : TrainingGame
{

    public Wall WallPrefab;

    public List<Wall> Walls;
    public Transform SpawnTransform;
    public Transform fitdisplay;
    

    private float CurrentTime;
    public override void ApplyTraining()
    {
       player.Fitness.Train(   Score);
        for (int i = 0; i < Mathf.RoundToInt( Score); i++)
        {
            UIpopup.Instance.DisplayNumberPopup(1);
        }
    }

    public override void Begin()
    {
        
        bStopped = false;
        CurrentTimeBetweenSpawns = MaxTimeBetweenSpawns;
        UIpopup.Instance.DisplayTextPopup("");

        player.GetComponent<Animator>().SetBool("Run",true);
        fitdisplay = FindObjectOfType<AttributeDisplay>().FitnessDisplay.transform;
        CurrentTime = MaxTimeBetweenSpawns;
    }

    public override void CheckPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump();
        }
    }

    public override void CleanUp()
    {
        for (int i = Walls.Count - 1; i >= 0; i--)
        {
            Destroy(Walls[i].gameObject);
        }
        Walls.Clear();

        Score = 0;
    }

    public override void EndTraining()
    {
        bStopped = true;
        player.GetComponent<Animator>().SetBool("Run", false);
        player.Wellness.Train(player.Wellness.Maximum / -4);

    }
    public override void Present()
    {
        bStopped = true;
        UIpopup.Instance.DisplayTextPopup(
            "Help Jamie practice co-ordination skills by jumping over the hurdles", Begin, true);

    }

    public override void UpdateTraining()
    {
        if (bStopped)
        {
            return;
        }


        CurrentTime += Time.deltaTime;
        if (CurrentTime > CurrentTimeBetweenSpawns)
        {
            // Spawn wall
            Wall newWall = Instantiate(WallPrefab);
            newWall.Init(this);
            newWall.transform.position = SpawnTransform.position;
            Walls.Add(newWall);
            CurrentTime = 0;
            CurrentTimeBetweenSpawns = CurrentTimeBetweenSpawns * TimeMulti;
            if (CurrentTimeBetweenSpawns < MinTimeBetweenSpawns)
            {
                CurrentTimeBetweenSpawns = MinTimeBetweenSpawns;
            }
        }
        for (int i = Walls.Count - 1; i >= 0; i--)
        {
            Walls[i].UpdateWall();
        }

    }
}
