using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeTraining : TrainingGame
{

    public KnowledgeProjectile[] KnowledgePrefabs;
    public Transform[] SpawnPositions;
    public Vector3[] MovementVecs;

    public List<KnowledgeProjectile> Projectiles;

    private float CurrentTime;


    public override void ApplyTraining()
    {
        player.Knowledge.Train( Score);

    }

    public override void Begin()
    {
        player = FindObjectOfType<Player>();
        bStopped = false;
        UIpopup.Instance.DisplayTextPopup("");

        CurrentTimeBetweenSpawns = MaxTimeBetweenSpawns;
    }

    public override void CheckPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.SetBarrierRotation(0);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.SetBarrierRotation(90);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.SetBarrierRotation(180);

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.SetBarrierRotation(270);

        }

    }

    public override void CleanUp()
    {
        for (int i = Projectiles.Count - 1; i >= 0; i--)
        {
            Destroy(Projectiles[i].gameObject);
        }
        Projectiles.Clear();
        Score = 0;
        player.Barrier.gameObject.SetActive(false   );

    }

    public override void EndTraining()
    {
        bStopped = true;
        player.Wellness.Train(player.Wellness.Maximum / -4);

    }

    public override void Present()
    {
        bStopped = true;
        player.Barrier.gameObject.SetActive(true);
        UIpopup.Instance.DisplayTextPopup("Block out Jamie’s cellphone notifications and focus on books!",Begin,true);
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

            
            CurrentTime = 0;
            CurrentTimeBetweenSpawns = CurrentTimeBetweenSpawns * TimeMulti;
            if (CurrentTimeBetweenSpawns < MinTimeBetweenSpawns)
            {
                CurrentTimeBetweenSpawns = MinTimeBetweenSpawns;
            }

            SpawnProjectile();

        }

        for (int i = Projectiles.Count - 1; i >= 0; i--)
        {
            Projectiles[i].UpdateProjectile();
        }
    }


    public void SpawnProjectile()
    {
        KnowledgeProjectile Proj = Instantiate(KnowledgePrefabs[Random.Range(0,KnowledgePrefabs.Length)]);
        int spawnpos = Random.Range(0,SpawnPositions.Length);


        Proj.transform.position = SpawnPositions[spawnpos].position;
        
        Proj.Init(this , MovementVecs[spawnpos] *0.75f);
        Projectiles.Add(Proj);
    }
}
