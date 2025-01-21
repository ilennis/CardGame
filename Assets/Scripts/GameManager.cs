using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public Text timeTxt;
    public Text warning;

    public Text attemptsCountTxt;
    public Text successCountTxt;

    public Card firstCard;
    public Card secondCard;

    public int cardCount = 0;

    int attempts = 0;
    int success = 0;
    int totalattempts = 0;
    int totalsuccess = 0;
    float time = 60.0f;

    public List<Card> cards = new List<Card>();


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
        attempts++;

        if((firstCard.arr_index != secondCard.arr_index) && (firstCard.index == secondCard.index))
        {
            success++;

            //리스트 삭제    
            cards.Remove(firstCard);
            cards.Remove(secondCard);

            //카드 삭제
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            
            cardCount -= 2;

            if (cardCount == 0)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                Card_Click_Status(false);

                Invoke("Card_click_ON", 0.5f);

            }
        }
        //틀리면 카드 다시 Close
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();

            Card_Click_Status(false);
            Invoke("Card_click_ON", 0.5f);
        }

    }
    public void AddSuccess(int victoryCount)
    {
        totalattempts += victoryCount;
        successCountTxt.text = totalattempts.ToString();
    }
    public void AddAttempts(int attemptscount)
    {
        totalattempts += attemptscount;
        attemptsCountTxt.text = totalattempts.ToString();
    }
    void Card_click_ON()
    {
        Card_Click_Status(true);
    }
    void Card_Click_Status(bool GET_status)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].cardStatus = GET_status;
        }
    }

}