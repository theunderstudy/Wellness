using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeProjectile : MonoBehaviour
{
    protected KnowledgeTraining knowledgeTraining;
    protected Vector3 movementvec;
    public virtual void Init(KnowledgeTraining training, Vector3 movement)
    {
        knowledgeTraining = training;
        movementvec = movement;

    }

    public virtual void UpdateProjectile()
    {
        transform.position += movementvec;
    }
        
}
