using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public Text timeTxt;
    public Text warning;

    public Text trycount;
    public Text successcount;

    public Card firstCard;
    public Card secondCard;

    public int cardCount = 0;

    int attemptscount = 0;
    int victorycount = 0;
    float time = 60.0f;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        //시간이 10초 남았을 때
        if (time <= 10.0f)
        {
            warning.gameObject.SetActive(true);
        }

        //시간이 다 됐을 때
        if (time <= 0f)
        {
            time = 0;
            SceneManager.LoadScene(3);
        }
    }

    public void Matched() // 카드 판별 시스템
    {
        attemptscount++;
        if(firstCard.index == secondCard.index)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            victorycount++;
            cardCount -= 2;
            if (cardCount == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
        //틀리면 카드 다시 Close
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
    }
    
}