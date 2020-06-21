using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public struct Attribute
{
    public Attribute(float min, float max, float starting)
    {
        Minimum = min;
        Maximum = max;
        Starting = starting;
        Current = starting;
    }
    public float Minimum;
    public float Maximum;
    public float Starting;
    public float Current;



    public void Train(float Addition)
    {
        Current += Addition;
        if (Current > Maximum)
        {
            Current = Maximum;
        }

        if (Current < Minimum)
        {
            Current = Minimum;
        }
    }
}
public class Player : MonoBehaviour
{
    // attributes

    public Attribute Knowledge = new Attribute(0, 10, 1);
    public Attribute Fitness = new Attribute(0, 10, 1);
    public Attribute Wellness = new Attribute(0, 10, 1);


    // ~attributes

    public Rigidbody2D RB;
    public float JumpStr = 10;
    float GroundDist;
    public GameObject Barrier;
    Animator anim;
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        GroundDist = GetComponent<BoxCollider2D>().bounds.extents.y;
        anim = GetComponent<Animator>();
    }
    public void Jump()
    {
        if (!grounded())
        {
            return;
        }
        RB.AddForce(new Vector2(0, JumpStr), ForceMode2D.Impulse);
    }

    public void SetBarrierRotation(int Z)
    {
        DOTween.Kill(Barrier.GetInstanceID());
        Barrier.transform.DOLocalRotate(new Vector3(0, 0, Z), 0.05f).SetId(Barrier.GetInstanceID());
    }
    public bool grounded()
    {

        // Debug.DrawLine(transform.position , transform.position - (-Vector3.up*( GroundDist + 0.1f)) , Color.red , 1.0f);

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, GroundDist + 0.1f);
        //if (hit)

        //    Debug.Log(hit.collider.gameObject.name);
        return RB.velocity == Vector2.zero;
    }
    private void Update()
    {
        anim.SetBool("Jump", !grounded());
    }
}
