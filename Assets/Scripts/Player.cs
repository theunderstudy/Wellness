using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
