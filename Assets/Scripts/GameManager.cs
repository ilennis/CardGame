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

    public Card firstCard;
    public Card secondCard;

    float time = 30.0f;


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

        //시간이 반절정도 갔을 때
        if (time <= 15.0f)
        {
            warning.gameObject.SetActive(true);
        }

        //시간이 다 됐을 때
        if (time <= 0f)
        {

        }
    }

    public void Matched() // 카드 판별 시스템
    {
        // 맞으면 카드 삭제
        if(firstCard.index == secondCard.index)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
        }
        //틀리면 카드 다시 Close
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
    }
    
}