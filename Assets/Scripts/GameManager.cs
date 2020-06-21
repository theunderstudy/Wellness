using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Day CurrentDay;

    public GameObject GameoverScreen;

    public Text StrGOText, KnlGOText;
    public string WinBoth, LoseBoth, WinExam, WinGame;
    public string[] IntroTexts;
    public int Count = 0;

    private void Start()
    {
        Application.targetFrameRate = 60;
        DisplayIntro();
    }

    public void DisplayIntro()
    {
        if (Count == IntroTexts.Length)
        {
            CurrentDay.BeginDaySection();
            return;
        }
        UIpopup.Instance.DisplayTextPopup(IntroTexts[Count], DisplayIntro,true);
        Count += 1;
    }


    // once this is done, start the game


    public void CheckGameover()
    {

        Player player = FindObjectOfType<Player>();
        TrainAttribute att = FindObjectOfType<TrainAttribute>();

        bool wonGame = player.Fitness.Current > att.FitnessTest;
        bool wonExam = player.Knowledge.Current > att.KnowledgeTest;
        string GOText;
        if (wonGame && wonExam)
        {
            GOText = WinBoth;
        }
        else if (wonGame)
        {
            GOText = WinGame;
        }
        else if (wonExam)
        {
            GOText = WinExam;
        }
        else 
        {
            GOText = LoseBoth;
        }
       

        UIpopup.Instance.gameObject.SetActive(false);

        GameoverScreen.gameObject.SetActive(true);

        gameoverscreen goscreen = FindObjectOfType<gameoverscreen>();
        goscreen.GameOverText.text = GOText;
    }


    private void Update()
    {

    }

}
