using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    public Button OffBtn;
    public GameObject Panel;
    public GameObject BackBtn;
    public GameObject Nextpanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Notion_OFF()
    {
        Panel.SetActive(false);
    }
    public void BackTxt()
    {
        Nextpanel.SetActive(true);
        Panel.SetActive(false);
    }
}
