using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIpopup : MonoBehaviour
{
    public Text PopupPrefab;
    public Text[] popups = new Text[20];
    public static UIpopup Instance;
    public int PopHeight = 10;
    public Color GoodColor = Color.green, BadColor = Color.red;
    private Player player;

    public TextMeshProUGUI Revealtext;
    public Image textbg;
    public delegate void TextCB(); // declare delegate type

    protected TextCB Callback; // to store the function
    private bool WaitForInput = false;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        for (int i = 0; i < popups.Length; i++)
        {
            popups[i] = Instantiate(PopupPrefab,transform);
            popups[i].gameObject.SetActive(false);
        }
    
    }
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }


    public void DisplayTextPopup(string text, TextCB CB = null ,bool bcontinue=false) 
    {
        StopCoroutine("Typewriter");
        StartCoroutine("Typewriter",(text));
        Callback = CB;
        WaitForInput = bcontinue;
        Debug.Log("wait for input" + WaitForInput);


    }
    private void Update()
    {
        if (WaitForInput)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                if (Callback!=null)
                {
                    Callback();
                }
            }
        }
    }

    public void DisplayNumberPopup(int number)
    {
        Text text = GetNextText();
        if (!text)
        {
            return;
        }
        Vector3 pos = Camera.main.WorldToScreenPoint(player.transform.position);
        pos.x += Mathf.Lerp(-1, 1, Random.Range(0, 1f));
        text.transform.position= pos;

        text.gameObject.SetActive(true);
        text.color = number > 0 ? GoodColor : BadColor;
        text.text = number.ToString();
        text.DOFade(0, 1).SetEase(Ease.InQuint).OnComplete(()=> text.gameObject.SetActive(false));
        text.transform.DOLocalMoveY(text.transform.localPosition.y + PopHeight , 0.75f).SetEase(Ease.OutQuint) ;

    }

    private Text GetNextText()
    {
        for (int i = 0; i < popups.Length; i++)
        {
            if (!popups[i].gameObject.activeInHierarchy)
            {
                return popups[i];
            }
        }

        return null;
    }

    IEnumerator Typewriter(string text)
    {
        Revealtext.text = "";
        textbg.gameObject.SetActive(false); 
        foreach (char c in text)
        {
            textbg.gameObject.SetActive(true);
            Revealtext.text = Revealtext.text + c;
            yield return new WaitForSeconds(.03f);
        }
        Debug.Log("wait for input"+ WaitForInput);
        if (WaitForInput)
        {
            yield return null;
        }
        else
        {
            if (Callback != null)
            {
                Callback();
                Callback = null;
            }
        }
        yield return null;
    }
}
