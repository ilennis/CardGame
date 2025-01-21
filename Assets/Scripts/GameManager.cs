using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text timeTxt;
    public Text warning;

    float time = 30.0f;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        
        //�ð��� �������� ���� ��
        if (time <= 15.0f)
        {
            warning.gameObject.SetActive(true);
        }

        //�ð��� �� ���� ��
        if (time <= 0f)
        {

        }
    }
}