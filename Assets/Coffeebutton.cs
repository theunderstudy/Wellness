using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coffeebutton : MonoBehaviour
{
    public Sprite[] Sprites;
    public Image myImage;
    int currentint = 0;

    public float timeBetween = 1;
    private float currentTime=0;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeBetween)
        {
            currentTime = 0;
            myImage.sprite = Sprites[currentint];
            currentint += 1;
            if (currentint == Sprites.Length)
            {
                currentint = 0;
            }
        }
    }
}
