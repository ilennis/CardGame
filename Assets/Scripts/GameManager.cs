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
    public Text match;
    public Text nomatch;

    public Card firstCard;
    public Card secondCard;

    public int cardCount = 0;

    public int Attempts = 0;
    public int Success = 0;
   
    float time = 30.0f;

    public List<Card> cards = new List<Card>();


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Ÿ�̸�
        if (time > 0)
        {
            time -= Time.deltaTime;
            timeTxt.text = time.ToString("N2");
            //�ð��� 10�� ������ ��
            if (time <= 10.0f)
            {
                warning.gameObject.SetActive(true);
            }
        }
        //Ÿ�̸Ӱ� ��������
        else
        {
            SceneManager.LoadScene(3);
        }
    }

    public void Matched() // ī�� �Ǻ� �ý���
    {
        GameManager.Instance.AddAttempts();
        //ī�� ��Ī�Ǿ��� ��
        if ((firstCard.arr_index != secondCard.arr_index) && (firstCard.index == secondCard.index))
        {
            Matchcard();

            //����Ʈ ����    
            cards.Remove(firstCard);
            cards.Remove(secondCard);

            //ī�� ����
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            
            cardCount -= 2;

            GameManager.Instance.AddSuccess();

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
        //Ʋ���� ī�� �ٽ� Close
        else
        {
            NotMatchcard();
            firstCard.CloseCard();
            secondCard.CloseCard();

            Card_Click_Status(false);
            Invoke("Card_click_ON", 0.5f);
        }

    }

    //����Ƚ�� ī��Ʈ
    public void AddSuccess()
    {
        Success++;
        // Data ���� PlayerPrefs.SetInt("successCountTxt", totalsuccess);
    }
    //�õ�Ƚ�� ī��Ʈ
    public void AddAttempts()
    {
        Attempts++;
       //  PlayerPrefs.SetInt("totalattempts", totalattempts);
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

    //ī�尡 ��Ī�Ǿ��ٴ� ����
    void Matchcard()
    {
        nomatch.gameObject.SetActive(false);
        match.gameObject.SetActive(true);
        Invoke("match.gameObject.SetActive(false)", 2.5f);
    }

    void NotMatchcard()
    {
        match.gameObject.SetActive(false);
        nomatch.gameObject.SetActive(true);
        Invoke("nomatch.gameObject.SetActive(false)", 2.5f);
    }

}