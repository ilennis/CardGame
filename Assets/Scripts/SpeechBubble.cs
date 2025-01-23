using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    public Scene_Hidden hidden;
    public Text bubbleText;

    void Start()
    {

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
