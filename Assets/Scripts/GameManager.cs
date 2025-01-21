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

        //�ð��� 10�� ������ ��
        if (time <= 10.0f)
        {
            warning.gameObject.SetActive(true);
        }

        //�ð��� �� ���� ��
        if (time <= 0f)
        {
            time = 0;
            SceneManager.LoadScene(3);
        }
    }

    public void Matched() // ī�� �Ǻ� �ý���
    {
        attempts++;

        if(firstCard.index == secondCard.index)
        {
            success++;

            //����Ʈ ����    
            cards.Remove(firstCard);
            cards.Remove(secondCard);

            //ī�� ����
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            
            cardCount -= 2;

            if (cardCount == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
        //Ʋ���� ī�� �ٽ� Close
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
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
    
}