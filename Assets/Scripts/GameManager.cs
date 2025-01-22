using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool IsEnded { get; set; } = false;

    public static GameManager Instance;

    public Text timeTxt;
    public Text warning;
    
    /// <summary>
    ///public Text match;
    /// public Text nomatch;
    /// </summary>

    public Animator Match;
    public Animator Nomatch;

    public Card firstCard;
    public Card secondCard;

    public int cardCount = 0;

    public int Attempts = 0;
    public int Success = 0;

    float time = 60.0f;

    public List<Card> cards = new List<Card>();


    private void Awake()
    {
        if (Instance == null)
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
        if (IsEnded)
        {
            return;
        }

        //Ÿ�̸�
        if (time > 0)
        {
            time -= Time.deltaTime;
            timeTxt.text = time.ToString("N2");
            //�ð��� 10�� ������ ��
            if (time <= 10.0f && !warning.gameObject.activeSelf)
            {
                warning.gameObject.SetActive(true);

                AudioManager.Instance.StopMusic();
                AudioManager.Instance.Play("Music_Warning");
            }
        }
        //Ÿ�̸Ӱ� ��������
        else
        {
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.Play("SoundFX_Defeat");

            SceneManager.LoadScene(3);
            IsEnded = true;
        }
    }

    public void Matched() // ī�� �Ǻ� �ý���
    {
        GameManager.Instance.AddAttempts();
        //ī�� ��Ī�Ǿ��� ��
        if ((firstCard.arr_index != secondCard.arr_index) && (firstCard.index == secondCard.index))
        {
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
                Matchcard();
                AudioManager.Instance.StopMusic();
                AudioManager.Instance.Play("SoundFX_Victory");

                SceneManager.LoadScene(2);
                IsEnded = true;
            }
            else
            {
                Matchcard();
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
        Match.SetBool("ismatch", true);
        if (cardCount != 0)
        {
            Invoke("ResetBool_m", 0.5f);
        }
        AudioManager.Instance.Play("SoundFX_Success");

        // match.gameObject.SetActive(false)
    }

    //ī�尡 ��Ī�����ʾҴٴ� ����
    void NotMatchcard()
    {
        Nomatch.SetBool("isnomatch", true);
        Invoke("ResetBool_n", 0.5f);
        AudioManager.Instance.Play("SoundFX_Fail");

    }

    void ResetBool_m()
    {
        Match.SetBool("ismatch", false);
    }

    void ResetBool_n()
    {
        Nomatch.SetBool("isnomatch", false);
    }
}