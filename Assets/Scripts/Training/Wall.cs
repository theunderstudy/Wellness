using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float MovementPerFrame = 0.1f;


    private StrengthTraining StrTrain;
    public void Init(StrengthTraining train)
    {
        StrTrain = train;
    }
    public void UpdateWall()
    {
        Vector3 Pos = transform.position;
        Pos.x -= MovementPerFrame;
        transform.position = Pos;   
    }

    bool bcancollider = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!bcancollider)
        {
            return;
        }

        if (collision.GetComponent<Player>())
        {
            bcancollider = false;
            Destroy(this.gameObject);
            StrTrain.Walls.Remove(this);
            StrTrain.Score += -1;
            UIpopup.Instance.DisplayNumberPopup(-1);
        }

        if (collision.GetComponent<WallGoal>())
        {
            bcancollider = false;
            StrTrain.Score += 1 + TrainAttribute.Instance.GetWellnessModifyer();
           
            UIpopup.Instance.DisplayNumberPopup(1 + TrainAttribute.Instance.GetWellnessModifyer());


           // Destroy(this.gameObject);

        }
    }
}
