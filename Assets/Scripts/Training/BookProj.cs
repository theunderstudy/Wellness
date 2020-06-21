using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookProj : KnowledgeProjectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Destroy(this.gameObject);
            knowledgeTraining.Projectiles.Remove(this);
            knowledgeTraining.Score += 1 + TrainAttribute.Instance.GetWellnessModifyer();
            UIpopup.Instance.DisplayNumberPopup(1 + TrainAttribute.Instance.GetWellnessModifyer());

        }

        if (collision.CompareTag("Barrier"))
        {           
             Destroy(this.gameObject);
            knowledgeTraining.Projectiles.Remove(this);
            knowledgeTraining.Score -= 1;
            UIpopup.Instance.DisplayNumberPopup(-1);



        }
    }

    
}
