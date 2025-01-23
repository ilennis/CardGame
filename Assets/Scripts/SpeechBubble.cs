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
        bubbleText.text = "제 사진이 아니에요.";  
    }

    public void CorrectText()
    {
        bubbleText.text = "감사합니다!";
    }

    public void RequestText()
    {
        Invoke("InvokeRequestText", hidden.speed);
    }

    private void InvokeRequestText()
    {
        bubbleText.text = "제 사진을 찾아주세요";
    }

}
