using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gameoverscreen : MonoBehaviour
{

    public Text GameOverText;
   public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
