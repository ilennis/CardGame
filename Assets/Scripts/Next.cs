using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Next : MonoBehaviour
{
    public Button NextBtn;
    public GameObject NextPanel;
    public GameObject Panel;
    public GameObject OffButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextTxt()
    {
        Panel.SetActive(true);
        NextPanel.SetActive(false);
    }
    public void Notion_OFF()
    {
        NextPanel.SetActive(false);
        Panel.SetActive(false);
    }
}
