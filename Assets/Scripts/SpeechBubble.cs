using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    public Scene_Hidden hidden;
    public Text bubbleText;

    private bool check;

    private void Awake()
    {
        check = false;
        bubbleText = this.GetComponentInChildren<Text>();
    }

    void Start()
    {
        //check = false;
        //this.gameObject.SetActive(false);
        

    }

    public void WrongText()
    {
        bubbleText.text = "�� ������ �ƴϿ���.";  
    }

    public void CorrectText()
    {
        bubbleText.text = "�����մϴ�!";
    }

    public void RequestText()
    {
        Invoke("InvokeRequestText", hidden.speed);
    }

    private void InvokeRequestText()
    {
        bubbleText.text = "�� ������ ã���ּ���";
    }

}
